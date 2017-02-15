
public class Worker {
	private String job;

	private int turn;
	private int number;
	private int mis_child;
	private boolean turn_miss = false;
	private int supplyFood;
	private int supplyToy;
	private int supplyHygiene;
	private int temp_time1;
	private int temp_time2;
	private double needMoney;
	private boolean flag_occupied=false; 
	private boolean flag_transPermission=false;
	
	public Worker(int n) {
		number = n;
	}
	

	public void duties(String jobP, int food, int toy, int hygiene) {
		flag_transPermission=false;
		if(jobP.equalsIgnoreCase("c")){job="missing";}
		else if(jobP.equalsIgnoreCase("m")){
			job="market";
			}
		if (!job.equalsIgnoreCase("missing")) {
			int amount = food + toy + hygiene;
			if (amount <= 100) {
				supplyFood = food;
				supplyToy = toy;
				supplyHygiene = hygiene;
				turn = 10;
				temp_time1 = ScreenTest.turn;
				flag_occupied=true;
			} else {
				System.out.println("You Shall not enter more than 100");
			}
		} else if (job.equalsIgnoreCase("missing")) {
			turn_miss = true;
		} else {
			System.out.println("Wrong Entry!");
		}
	}
	
	
	public void timeNturn() {
		temp_time2 = ScreenTest.turn;
		if (temp_time2 - temp_time1 == turn) {
			turn = 0;
			flag_occupied=false;
			flag_transPermission=true;
		}
	}

	public boolean isFlag_transPermission() {
		return flag_transPermission;
	}

	public void setFlag_transPermission(boolean flag_transPermission) {
		this.flag_transPermission = flag_transPermission;
	}

	public int getTemp_time1() {
		return temp_time1;
	}

	public void setTemp_time1(int temp_time1) {
		this.temp_time1 = temp_time1;
	}

	public void displayWorkerInfos() {
		if (job.equalsIgnoreCase("Market")) {
			System.out.print("(Market" + " -");
			if (supplyFood > 0) {
				System.out.print(" Food:" + supplyFood);
			} else if (supplyHygiene > 0) {
				System.out.print(" Hygiene Mat.:" + supplyHygiene);
			} else if (supplyToy > 0) {
				System.out.print(" Toy:" + supplyToy);
			}
			System.out.print(")");
		} else if (job.equals("Missing")) {
			System.out.print("(Missing child " + mis_child);
			System.out.print(")");
		}
	}

	

	public String getJob() {
		return job;
	}
	public void setJob(String job) {
		this.job = job;
	}
	public int getTurn() {
		return turn;
	}
	public void setTurn(int turn) {
		this.turn = turn;
	}
	public int getNumber() {
		return number;
	}
	public void setNumber(int number) {
		this.number = number;
	}

	public boolean isTurn_miss() {
		return turn_miss;
	}
	public void setTurn_miss(boolean turn_miss) {
		this.turn_miss = turn_miss;
	}
	public int getSupplyFood() {
		return supplyFood;
	}
	public void setSupplyFood(int supplyFood) {
		this.supplyFood = supplyFood;
	}
	public int getSupplyToy() {
		return supplyToy;
	}
	public void setSupplyToy(int supplyToy) {
		this.supplyToy = supplyToy;
	}
	public int getSupplyHygiene() {
		return supplyHygiene;
	}
	public void setSupplyHygiene(int supplyHygiene) {
		this.supplyHygiene = supplyHygiene;
	}
	public double getNeedMoney() {
		return needMoney;
	}
	public void setNeedMoney(double needMoney) {
		this.needMoney = needMoney;
	}
	public int getMis_child() {
		return mis_child;
	}
	public void setMis_child(int mis_child) {
		this.mis_child = mis_child;
	}
	public boolean isFlag_occupied() {
		return flag_occupied;
	}
	public void setFlag_occupied(boolean flag_occupied) {
		this.flag_occupied = flag_occupied;
	}

}