import java.util.*;
import java.text.DecimalFormat;

public class GameManagement {
	// private Boolean PauseGame=false; //buraya bakcaz
	private Child[] children;
	private Worker[] workers;
	private Carer[] carers;
	private int countChildren; // Hepsine teker teker yapmak yerine bir tane //
								// count yapmak olur muydu??
	private int countWorkers;
	private int countCarers;
	private double credit = 200;
	private double currentAVGH;
	private double score;
	private int gameFood = 0;
	private int gameToy = 0;
	private int gameHygiene = 0;
	private double carersupplies;
	private double childnumber;
	private double personalnumber2;
	private int pers_numb;
	private int child_numb;
	private int amount_food;
	private int amount_toy;
	private int amount_hygiene;
	private String market_Item2 = "n";
	private String market_Item3 = "n";
	private boolean is_accepted = false;
	private DecimalFormat df = new DecimalFormat("#,##");
	
	
	public GameManagement() {

		children = new Child[100];
		workers = new Worker[100];
		carers = new Carer[100];
		children[0] = new Child(1);
		carers[0] = new Carer(1);
		workers[0] = new Worker(1);
		this.countChildren = 1;
		this.countWorkers = 1;
		this.countCarers = 1;

	}
	
	public void Screen_Child(enigma.console.Console cn) {// saðda ki cocuklar
		for (int i = 0; i < countChildren; i++) {
			if (children[i].isAccept() == true &&(children[i].getPersonaljob().equalsIgnoreCase("c")
					||children[i].getPersonaljob().equalsIgnoreCase("f")
					||children[i].getPersonaljob().equalsIgnoreCase("g")
					||children[i].getPersonaljob().equalsIgnoreCase("h")
					||children[i].getPersonaljob().equalsIgnoreCase("m")
					)) {
				cn.getTextWindow().setCursorPosition(70, 8);
				System.out.print("Child " + children[i].getChildNumber());
				if(children[i].isFlag_missing()==false){
					cn.getTextWindow().setCursorPosition(70, 9);
					System.out.print("Happy: " + df.format(children[i].getHappiness()));
					cn.getTextWindow().setCursorPosition(70, 10);
					System.out.print("F: " + df.format(children[i].getFood()) + " G: " + df.format(children[i].getToyGame()));
					cn.getTextWindow().setCursorPosition(70, 11);
					System.out.print("S: " + df.format(children[i].getSleep()) + " H: " + df.format(children[i].getHygiene()));
				}
				else{
				cn.getTextWindow().setCursorPosition(70, 9);
				System.out.print("Missing: " + df.format(children[i].getMissing()));
				cn.getTextWindow().setCursorPosition(70, 11);
				System.out.println("                                  ");
				}
			
			}
		}
	}
	public void Screen(enigma.console.Console cn) {

		System.out.print("Current avg. Happiness: " + df.format(getCurrentAVGH()));
		System.out.print("    Credit: " + getCredit());
		System.out.print("    Score: " + df.format(getScore()));
		cn.getTextWindow().setCursorPosition(0, 2);
		System.out.println("---Applications---");
		if (ScreenTest.applicationcontrol) {
			cn.getTextWindow().setCursorPosition(0, 3);// cocugun degerleri
														// atýlcak
			System.out.print("You have Child application: ");
			children[countChildren-1].displayChildInfo();
		}
		if (ScreenTest.applicationcontrol2) {
			cn.getTextWindow().setCursorPosition(0, 4);
			System.out.print("You have Worker application");
		}
		if (ScreenTest.applicationcontrol3) {
			cn.getTextWindow().setCursorPosition(0, 5);
			System.out.print("You have Carer application");
		}
		cn.getTextWindow().setCursorPosition(0, 6);
		System.out.println("---Children---");
		displayAllChildren();
		
		cn.getTextWindow().setCursorPosition(0, 13);
		System.out.println("---Carers---");
		displayAllCarers();
		
		cn.getTextWindow().setCursorPosition(0, 15);
		System.out.println("---Workers---");
		displayAllWorker();
	}

	public void displayAllChildren() {
		for (int i = 0; i < countChildren; i++) {
			if (i % 4 == 0) {
				System.out.println();
			} else {
				System.out.print("         ");
			}
			
			children[i].displayChildInfos();
		}
	}
	public void displayAllWorker() {
		for (int i = 0; i < countWorkers; i++) {
			if (workers[i].isFlag_occupied() == true) {
				System.out.print("Worker: " + workers[i].getNumber());
				workers[i].displayWorkerInfos();
			}
		}
	}
	public void displayAllCarers() {
		for (int i = 0; i < countCarers; i++) {
			if (!carers[i].getCarer_Job().equalsIgnoreCase("n")) {
				System.out.print("Carer: " + carers[i].getCarer_Number());
				System.out.print(" ("+"Child "+carers[i].getCarer_Child()+" "+carers[i].getCarer_Job());
				if(carers[i].getCarer_Job().equalsIgnoreCase("f")){
					System.out.print(":"+carers[i].getTemp()+" "); 
				}
				else if(carers[i].getCarer_Job().equalsIgnoreCase("g")){
					System.out.print(":"+carers[i].getTemp()+" ");
				}
				else if(carers[i].getCarer_Job().equalsIgnoreCase("h")){
					System.out.print(":"+carers[i].getTemp()+" ");
				}
				carers[i].displayCarerInfos();
			}
		}
	}

	
	public void createMember(String applicationtype) {
		if (applicationtype.equals("ch")) {
			countChildren++;
			children[countChildren - 1] = new Child(countChildren);
			children[countChildren - 1].setAccept(false);
															
		} else if (applicationtype.equals("wr")) {
			countWorkers++;
			workers[countWorkers - 1] = new Worker(countWorkers);
		} else if (applicationtype.equals("cr")) {
			countCarers++;
			carers[countCarers - 1] = new Carer(countCarers);
		}
	}
	public void deleteMemeber() {
		children[countChildren - 1] = null;
		countChildren--;
	}
	
	public void parsing(String command,enigma.console.Console cn) {
		String[] commandparts = command.split("-"); // kelimeleri parçalara
													// ayýrma

		String personaljob = commandparts[0].substring(0, 2); // cr/wr/ch ayýrma
		if (!personaljob.equalsIgnoreCase("ap")) {
			String personalnumber = commandparts[0].substring(2, 4);// sayýsal
																	// deðeler

			personalnumber2 = Double.parseDouble(personalnumber);// string
																	// sayýyý
																	// int
																	// dönüþtürme

		} else {
			String personalnumber = commandparts[1].substring(0, 2);
			personalnumber2 = Double.parseDouble(personalnumber);// string
																	// sayýyý

		}

		numChoser();
		if (personaljob.equals("cr")) { // carer operasyonlarý

			String carerjob = commandparts[1].substring(0, 1);

			switch (carerjob) {
			case "f": {
				String childnumber1 = commandparts[2].substring(2, 4);
				childnumber = Double.parseDouble(childnumber1); // Finds Child
																// number

				numChoser2();

				String carersupps = commandparts[3].substring(0, 2);
				int var = Integer.parseInt(carersupps); // Amount of
				carersupplies = (double) var; // Supplies
				if(children[child_numb-1].isFlag_missing()==false){
				supTransfer(carerjob, carersupplies, pers_numb, child_numb);
				children[child_numb - 1].setPersonal(commandparts[0]);
				children[child_numb - 1].setPersonaljob(carerjob);
				}
				else{
					cn.getTextWindow().setCursorPosition(0, 19);
					System.out.println("You can't give supply to missing child");
					
				}
			}
				break;
			case "h": {
				String childnumber1 = commandparts[2].substring(2, 4);
				childnumber = Double.parseDouble(childnumber1); // Finds Child
																// number

				numChoser2();

				String carersupps = commandparts[3].substring(0, 2);
				int var = Integer.parseInt(carersupps); // Amount of
				carersupplies = (double) var; // Supplies

				if(children[child_numb-1].isFlag_missing()==false){
					supTransfer(carerjob, carersupplies, pers_numb, child_numb);
					children[child_numb - 1].setPersonal(commandparts[0]);
					children[child_numb - 1].setPersonaljob(carerjob);
					}
					else{
						cn.getTextWindow().setCursorPosition(0, 19);
						System.out.println("You can't give supply to missing child");
						
					}

			}
				break;
			case "g": {
				String childnumber1 = commandparts[2].substring(2, 4);
				childnumber = Double.parseDouble(childnumber1); // Finds Child
																// number

				numChoser2();

				String carersupps = commandparts[3].substring(0, 2);
				int var = Integer.parseInt(carersupps); // Amount of
				carersupplies = (double) var; // Supplies

				if(children[child_numb-1].isFlag_missing()==false){
					supTransfer(carerjob, carersupplies, pers_numb, child_numb);
					children[child_numb - 1].setPersonal(commandparts[0]);
					children[child_numb - 1].setPersonaljob(carerjob);
					}
					else{
						cn.getTextWindow().setCursorPosition(0, 19);
						System.out.println("You can't give supply to missing child");
						
					}
			}
				break;
			
			case "s": {// sleep child
				if (commandparts.length > 2) {
					String carersupps = commandparts[3].substring(0, 2);
					int var = Integer.parseInt(carersupps);//// string 03
					carersupplies = (double) var; //// >> int
					//// 03
					if(children[child_numb-1].isFlag_missing()==false){
						supTransfer(carerjob, carersupplies, pers_numb, child_numb);
						children[child_numb - 1].setPersonal(commandparts[0]);
						children[child_numb - 1].setPersonaljob(carerjob);
						}
						else{
							cn.getTextWindow().setCursorPosition(0, 19);
							System.out.println("You can't give supply to missing child");
							
						}
				} else {
					
					if(children[child_numb-1].isFlag_missing()==false){
						supTransfer(carerjob, 0, pers_numb, child_numb);
						children[child_numb - 1].setPersonal(commandparts[0]);
						children[child_numb - 1].setPersonaljob(carerjob);
						}
						else{
							cn.getTextWindow().setCursorPosition(0, 19);
							System.out.println("You can't give supply to missing child");
							
						}
				}
			}
				break;
			case "c": {// check child
				String childnumber1 = commandparts[2].substring(2, 4);
				childnumber = Double.parseDouble(childnumber1);
				numChoser2();
				supTransfer(carerjob, 0, pers_numb, child_numb);
				
				children[child_numb - 1].setPersonal(commandparts[0]);
				children[child_numb - 1].setPersonaljob(carerjob);
			}
				break;
			case "r": {// terminate job
				carers[pers_numb-1].setCarer_Turn2(ScreenTest.turn);
				
				if(carers[pers_numb-1].getCarer_Turn2()-carers[pers_numb-1].getCarer_Turn()>=2){//Gecen turn 2'den fazlaysa
					carers[pers_numb-1].setCarer_Job("n");//direk sonlandýr
					
				}
				else if(carers[pers_numb-1].getCarer_Turn2()-carers[pers_numb-1].getCarer_Turn()<2){//2'den az ise turn beklet
					cn.getTextWindow().setCursorPosition(0, 19);
					System.out.println("You have to wait more turn");
					
				}
			}
				break;
			case "t":
				System.out.println("terminate contract for carer" + personalnumber2);
				break;
			default:
				carerjob = "Invalid job";
				break;
			}
		} else if (personaljob.equals("wr")) {
			String carerjob = commandparts[1].substring(0, 1);
			switch (carerjob) {
			case "m": {
				String market_Item1 = commandparts[2].substring(0, 1);
				if (commandparts.length > 4) {
					market_Item2 = commandparts[3].substring(0, 1);
				} else if (commandparts.length > 5) {
					market_Item3 = commandparts[4].substring(0, 1);
				}

				if (market_Item1.equalsIgnoreCase("f")) {
					amount_food = Integer.parseInt(commandparts[2].substring(2, 4));
				} else if (market_Item1.equalsIgnoreCase("g")) {
					amount_toy = Integer.parseInt(commandparts[2].substring(2, 4));
				} else if (market_Item1.equalsIgnoreCase("h")) {
					amount_hygiene = Integer.parseInt(commandparts[2].substring(2, 4));
				}

				if (market_Item2.equalsIgnoreCase("g")) {
					amount_toy = Integer.parseInt(commandparts[3].substring(2, 4));
				} else if (market_Item2.equalsIgnoreCase("f")) {
					amount_food = Integer.parseInt(commandparts[3].substring(2, 4));
				} else if (market_Item2.equalsIgnoreCase("h")) {
					amount_hygiene = Integer.parseInt(commandparts[3].substring(2, 4));
				}

				if (market_Item3.equalsIgnoreCase("h")) {
					amount_hygiene = Integer.parseInt(commandparts[4].substring(2, 4));
				} else if (market_Item3.equalsIgnoreCase("g")) {
					amount_toy = Integer.parseInt(commandparts[4].substring(2, 4));
				} else if (market_Item3.equalsIgnoreCase("f")) {
					amount_food = Integer.parseInt(commandparts[4].substring(2, 4));
				}
				workers[pers_numb - 1].duties(carerjob, amount_food, amount_toy, amount_hygiene);

			}
				break;
			case "c":// find child
				String childnumber1 = commandparts[2].substring(2, 4);
				childnumber = Double.parseDouble(childnumber1); // Finds Child
																// number

				numChoser2();
				children[child_numb - 1].setChild_finder_number(pers_numb - 1);
				workers[pers_numb - 1].duties(carerjob, 0, 0, 0);

				children[child_numb - 1].setPersonal(commandparts[0]);
				children[child_numb-1].setPersonaljob("m");
				break;
			case "t":
				System.out.println("terminate contract for worker" + personalnumber2);
				break;

			default:
				carerjob = "Invalid job";
				break;
			}
		} else if (personaljob.equals("ap")) {
			if (pers_numb == 1) {
				ScreenTest.applicationcontrol = false;
				is_accepted = true;
				children[countChildren - 1].setAccept(true);
			} else if (pers_numb == 2) {
				createMember("wr");//EDÝTED wr-cr yerleri deðiþti**************
				ScreenTest.applicationcontrol2 = false;
			} else if (pers_numb == 3) {
				createMember("cr");
				ScreenTest.applicationcontrol3 = false;
			}
		}
		
	}

	public void workerTunneltime(int i) {
		workers[i].timeNturn();
		if (workers[i].isFlag_transPermission() == true) {
			gameFood = gameFood + workers[i].getSupplyFood();
			gameToy = gameToy + workers[i].getSupplyToy();
			gameHygiene = gameHygiene + workers[i].getSupplyHygiene();

			workers[i].setSupplyFood(0);
			workers[i].setSupplyHygiene(0);
			workers[i].setSupplyToy(0);
		}
	}
	public void supTransfer(String job, double sup, int i, int j) {
		carers[i - 1].setCarer_Job(job);
		carers[i - 1].setCarer_Child(j - 1);
		carers[i - 1].setCarer_amount(sup);

	}

	public void carerJobinvoker() {
		for (int i = 0; i < countCarers; i++) {
			
			carers[i].Job(children);
			
		}
	}

	public Worker[] getWorkers() {
		return workers;
	}

	public void discreaseChild() {
		for (int i = 0; i < countChildren; i++) {
			children[i].discreaseFood();
			children[i].discreaseToyGame();
			children[i].discreaseSleep();
			children[i].discreaseHygiene();
		}
	}

	public void addChildren(Child c) {
		children[countChildren] = c;
		countChildren++;
	}
	public void addWorker(Worker w) {
		workers[countWorkers] = w;
		countWorkers++;
	}
	public void addCarer(Carer ca) {
		carers[countCarers] = ca;
		countCarers++;
	}

	public void numChoser() {
		if (personalnumber2 == 01) {
			pers_numb = 1;
		} else if (personalnumber2 == 02) {
			pers_numb = 2;
		} else if (personalnumber2 == 03) {
			pers_numb = 3;
		} else if (personalnumber2 == 04) {
			pers_numb = 4;
		} else if (personalnumber2 == 05) {
			pers_numb = 5;
		} else if (personalnumber2 == 06) {
			pers_numb = 6;
		} else if (personalnumber2 == 07) {
			pers_numb = 7;
		} else if (personalnumber2 == 08D) {
			pers_numb = 8;
		} else if (personalnumber2 == 09D) {
			pers_numb = 9;
		}

	}
	public void numChoser2() {
		if (childnumber == 01) {
			child_numb = 1;
		} else if (childnumber == 02) {
			child_numb = 2;
		} else if (childnumber == 03) {
			child_numb = 3;
		} else if (childnumber == 04) {
			child_numb = 4;
		} else if (childnumber == 05) {
			child_numb = 5;
		} else if (childnumber == 06) {
			child_numb = 6;
		} else if (childnumber == 07) {
			child_numb = 7;
		} else if (childnumber == 08D) {
			child_numb = 8;
		} else if (childnumber == 09D) {
			child_numb = 9;
		}

	}

	public void tunnelHappiness() {
		for (int i = 0; i < countChildren; i++) {
			children[i].calcHappiness();
		}
	}

	public int getGameFood() {
		return gameFood;
	}

	public void setGameFood(int gameFood) {
		this.gameFood = gameFood;
	}

	public int getGameToy() {
		return gameToy;
	}

	public void setGameToy(int gameToy) {
		this.gameToy = gameToy;
	}

	public int getGameHygiene() {
		return gameHygiene;
	}

	public void setGameHygiene(int gameHygiene) {
		this.gameHygiene = gameHygiene;
	}

	

	public double getScore() { // bunu günün sonuna geldiysek
		// hesaplasýn??
		if (ScreenTest.turn == 49) {
			score = countChildren * (currentAVGH - 50);
		}
		return score;
	}

	public void creditCalculate() { // bütün çoçuklarýn o anki mutluluklarý ile
		// toplam krediye eklendi.
		if (ScreenTest.turn == 49) {
			for (int i = 0; i < countChildren; i++) {
				credit += children[i].getHappiness() * (1 + ((children[i + 1].getHappiness() - 50) / 50));
			}
		}
	}
	public void ScoreCalculate() {
		if (ScreenTest.turn == 49) {
			score = countChildren * (currentAVGH - 50);
		}
	}

	public void MissingChildCalculate() { 
		Random rnd = new Random();
		for (int i = 0; i < countChildren; i++) {
			if (children[i].getHappiness() < 25) {
				int var = rnd.nextInt(100) + 1;
				if (var == 1 && children[i].isFlag_missing() == false) {
					children[i].setFlag_missing(true);

				}
			}
			if (children[i].isFlag_missing() == true) {
				if (children[i].getChild_finder_number() == -1) {
					int var2 = children[i].getMissing();
					children[i].setMissing(var2 + 1);
				} else {
					if (children[i].getMissing() != 0) {
						children[i].setMissing(children[i].getMissing() - 1);
					}
					if (children[i].getMissing() == 0) {
						workers[children[i].getChild_finder_number()].setTurn_miss(false);
						children[i].setChild_finder_number(-1);
					}

				}
			}

		}
	}

	public void payWagesEndOfTheDay() { // Kontroller yapýlacak
		if (ScreenTest.turn == 49) {
			credit -= ((50 * countCarers) + (30 * countWorkers));
			for (int i = 0; i < countChildren; i++) {
				if (children[i].getHappiness() < 10) // gunun sonunda eðer
														// çocuðun
				{
					credit -= 50;
				}
			}
			if (credit < 0) // eðer bu iþlemler sonucu kredi negatif olursa oyun
			{
				System.out.println("GAME OVER");
			}
		}
	}

	public void setCurrentAVGH(double currentAVGH) {
		this.currentAVGH = currentAVGH;
	}

	public int getCountChildren() {
		return countChildren;
	}
	public void TunnelChild() {
		children[countChildren].displayChildInfos();
	}

	public double getCurrentAVGH() {
		double toplam = 0;
		if (ScreenTest.turn == 49) {
			for (int i = 0; i < countChildren; i++) {
				toplam += children[i].getHappiness(); // bütün çoçuklarýn toplam
														// mutluluðu
			}
			currentAVGH = toplam / countChildren;
			df.format(currentAVGH);
		}
		return currentAVGH; // Ortalama hesaplar.
	}

	public double getCredit() {
		double temp = 0;
		if (ScreenTest.turn == 49) {
			for (int i = 0; i < countChildren; i++) { // her çoçuk için ayrý
														// kredi
														// hesaplayýp toplam
														// krediyi
														// bulacak.
				temp = children[i].getHappiness() * ((children[i].getHappiness() - 50) / 50);
				credit += temp;
			}
		}
		return credit;
	}
	public void setCountChildren(int countChildren) {
		this.countChildren = countChildren;
	}
	public int getCountWorkers() {
		return countWorkers;
	}
	public void setCountWorkers(int countWorkers) {
		this.countWorkers = countWorkers;
	}
	public int getCountCarers() {
		return countCarers;
	}
	public void setCountCarers(int countCarers) {
		this.countCarers = countCarers;
	}
	public Child[] getChildren() {
		return children;
	}
	public void setChildren(Child[] children) {
		this.children = children;
	}
	public void setWorkers(Worker[] workers) {
		this.workers = workers;
	}
	public Carer[] getCarers() {
		return carers;
	}
	public void setCarers(Carer[] carers) {
		this.carers = carers;
	}
	public boolean isIs_accepted() {
		return is_accepted;
	}
	public void setIs_accepted(boolean is_accepted) {
		this.is_accepted = is_accepted;
	}

}
