
public class Tree {

	private final int buildingCost = 50;
	private final int productionTime = 5;
	private String name;
	private int life;
	private int location;
	private int food;
	private Coordinat cord;

	

	public Tree(int x, int y) {
		name = "T";
		this.life = 50;
		this.food = 0;
		cord=new Coordinat(x,y);
	}
	
	public void setFood() {
		if (food <= 50) {
			food++;
		}
	}
	
	public void damageLife(int damage) {
		life = life-damage;
	}
	public int collectFood(int food) {
		return food;
	}
	public void generateFood() {
		if(food<51){
			food+=5;
		}
	}

	public String getName() {
		return name;
	}

	public int getLife() {
		return life;
	}
	public int getBuildingCost() {
		return buildingCost;
	}
	public int getProductionTime() {
		return productionTime;
	}

	public int getFood() {
		return food;
	}

	public void setFood(int food) {
		this.food = food;
	}

	
	
}
