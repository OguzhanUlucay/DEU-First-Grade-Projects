import java.util.concurrent.ThreadLocalRandom;
import java.util.*;
import java.text.DecimalFormat;

public class Child {
	private int childnumber;
	private double dfood;
	private double dtoyGame;
	private double dhygiene;
	private double dsleep;
	private double food;
	private double sleep;
	private double toygame;
	private double hygiene;
	private double happiness;
	
	
	private int missing;
	private boolean flag_missing=false;
	private int child_finder_number=-1;

	private String personal="  ";
	private String personaljob=" ";
	
	private boolean accept=true;
	
	DecimalFormat df = new DecimalFormat("#.##");

	public Child(int n) {

		this.childnumber = n;
		/////////////// value
		int min = 25;//25
		int max = 75;//75
		this.happiness = ThreadLocalRandom.current().nextInt(min, max);
		this.food = ThreadLocalRandom.current().nextInt(min, max);
		this.sleep = ThreadLocalRandom.current().nextInt(min, max);
		this.toygame = ThreadLocalRandom.current().nextInt(min, max);
		this.hygiene = ThreadLocalRandom.current().nextInt(min, max);
		double minf = 0.50;
		double maxf = 1.50;
		this.dfood = ThreadLocalRandom.current().nextDouble(minf, maxf);
		double mintG = 0.50;
		double maxtG = 1.50;
		this.dtoyGame = ThreadLocalRandom.current().nextDouble(mintG, maxtG);
		double minh = 0.20;
		double maxh = 0.50;
		this.dhygiene = ThreadLocalRandom.current().nextDouble(minh, maxh);
		double mins = 0.25;
		double maxs = 0.75;
		this.dsleep = ThreadLocalRandom.current().nextDouble(mins, maxs);
		this.missing = 0;
	}

	public void displayChildInfos() {//solda ki
		if(accept==true){
			
		System.out.print("Child " + childnumber);
	
		if(personaljob.equalsIgnoreCase("c")){
			System.out.println("M:"+missing);
			System.out.print(personal+" "+personaljob);
		}
		else if(personaljob.equalsIgnoreCase("f")){
			System.out.println(" F:" + df.format(food));
			System.out.print(personal+" "+personaljob);
		}
		else if(personaljob.equalsIgnoreCase("g")){
			System.out.println(" G:" + df.format(toygame));
			System.out.print(personal+" "+personaljob);
		}
		else if(personaljob.equalsIgnoreCase("s")){
			System.out.println(" S:" + df.format(sleep));
			System.out.print(personal+" "+personaljob);
		}
		else if(personaljob.equalsIgnoreCase("h")){
			System.out.println(" H:" + df.format(hygiene));
			System.out.print(personal+" "+personaljob);
		}
		else if(!personal.equalsIgnoreCase("  ")&&personaljob.equalsIgnoreCase(" ")){
			System.out.println(" M:"+df.format(missing));
			System.out.print(personal+" finding...");
		}
		}
	}
	
	public void displayChildInfo() {
		System.out.println("Child App: F:" + df.format(dfood)+" H:" + df.format(dhygiene)+ " S:" + df.format(dsleep)+ " G:" + df.format(dtoyGame));
	}

	public double discreaseHygiene() {
		hygiene = hygiene - dhygiene;
		return this.hygiene;
	}

	public double discreaseSleep() {
		sleep = sleep - dsleep;
		return this.sleep;
	}

	public double discreaseFood() {
		food = food - dfood;
		return this.food;
	}

	public double discreaseToyGame() {
		toygame = toygame - dtoyGame;
		return this.toygame;
	}

	public int getChildNumber() {
		return childnumber;
	}

	public void setChildNumber(int childnumber) {
		this.childnumber = childnumber;
	}

	public void calcHappiness() {

		if (food < 75 && food > 25) {
			happiness = happiness + happinessRateForFood(1);
		} else if (food > 75) {
			happiness = happiness -(2 * 0.24);
		} else if (food < 25) {
			happiness = happiness -(4 * 0.24);

		}
		if (toygame < 75 && toygame > 25) {
			happiness = happiness + happinessRateForToyGame(1);

		} else if (toygame > 75) {
			happiness = happiness -  (2 * 0.12);

		} else if (toygame < 25) {
			happiness = happiness -  (4 * 0.12);

		}
		if (hygiene < 75 && hygiene > 25) {

			happiness = happiness + happinessRateForHygiene(1);
		} else if (hygiene > 75) {
			happiness = happiness -  (2 * 0.06);

		} else if (hygiene < 25) {
			happiness = happiness - (4 * 0.06);

		}
		if (sleep < 75 && sleep > 25) {
			happiness = happiness + happinessRateForSleep(1);

		} else if (sleep > 75) {
			happiness = happiness -  (2 * 0.08);

		}else if (sleep < 25) {
			happiness = happiness -  (4 * 0.08);

		}

	}

	public double happinessRateForFood(double supply) {
		return supply * 0.24;
	}

	public double happinessRateForSleep(double supply) {
		return supply * 0.08;
	}

	public double happinessRateForToyGame(double supply) {
		return supply * 0.12;
	}

	public double happinessRateForHygiene(double supply) {
		return supply * 0.06;
	}

	public int getChildnumber() {
		return childnumber;
	}

	public void setChildnumber(int childnumber) {
		this.childnumber = childnumber;
	}

	public double getDfood() {
		return dfood;
	}

	public double getDtoyGame() {
		return dtoyGame;
	}

	public double getDhygiene() {
		return dhygiene;
	}

	public double getDsleep() {
		return dsleep;
	}

	public double getFood() {
		//double food2 = Double.parseDouble(df.format(food));

		return food;
	}

	public void setFood(double food) {
		this.food = food;
	}

	public double getSleep() {
		return sleep;
	}

	public void setSleep(double sleep) {
		this.sleep = sleep;
	}

	public double getToyGame() {
		return toygame;
	}

	public void setToyGame(double toyGame) {
		this.toygame = toyGame;
	}

	public double getHygiene() {
		return hygiene;
	}

	public void setHygiene(double hygiene) {
		this.hygiene = hygiene;
	}

	public double getHappiness() {
		return happiness;
	}

	public void setHappiness(double happiness) {
		this.happiness = happiness;
	}
	public void setFlag_missing(boolean flag_missing) {
		this.flag_missing = flag_missing;
	}

	public int getMissing() {
		return missing;
	}

	public void setMissing(int missing) {
		this.missing = missing;
	}

	public int getChild_finder_number() {
		return child_finder_number;
	}

	public void setChild_finder_number(int child_finder_number) {
		this.child_finder_number = child_finder_number;
	}
	public boolean isFlag_missing() {
		return flag_missing;
	}
	public String getPersonal() {
		return personal;
	}

	public void setPersonal(String personal) {
		this.personal = personal;
	}

	public String getPersonaljob() {
		return personaljob;
	}

	public void setPersonaljob(String personaljob) {
		this.personaljob = personaljob;
	}

	public boolean isAccept() {
		return accept;
	}

	public void setAccept(boolean accept) {
		this.accept = accept;
	}
	
}