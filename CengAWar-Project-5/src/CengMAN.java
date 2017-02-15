
public class CengMAN {
	private static int life, atackDamage;
	private static int counter = 0;
	private int range, creatingTime, cost;
	private int atackSpeed, movementSpeed, level;
	private String name;
	private Stack backPack = new Stack(8);
	private Coordinat coordination;

	public CengMAN(int x,int y) {
		coordination = new Coordinat(x, y);// burasý deðiþti
		name = "C" + counter;
		life = 100;
		atackDamage = 10;
		creatingTime = 8;
		cost = 50;
		atackSpeed = 1;
		movementSpeed = 1;
		level = 1;
		counter++;
	}

	public void fillInventory(Object data) {
		backPack.push(data);

	}

	public Object extractInventory() {
		return backPack.pop();
	}

	public void displayInventory() {
		int a = 17;
		Stack tempStack = new Stack(8);
		while (a>9) {
			
			if(backPack.peek()!=null){
				GameManagament.cn.getTextWindow().setCursorPosition(56, a);
				if (backPack.peek().getClass().getName().equals("Food")) {
					GameManagament.cn.getTextWindow().output("|" + "F" + "|");
				}

				else if (backPack.peek().getClass().getName().equals("Cement")) {
					GameManagament.cn.getTextWindow().output("|" + "C" + "|");
				} else if (backPack.peek().equals("Crushed")) {
					GameManagament.cn.getTextWindow().output("|" + "~" + "|");
				}
				tempStack.push(backPack.pop());
			}
			else{
				GameManagament.cn.getTextWindow().setCursorPosition(56, a);
				GameManagament.cn.getTextWindow().output("| |");
			}
			a--;
		}
		GameManagament.cn.getTextWindow().setCursorPosition(56, 18);
		GameManagament.cn.getTextWindow().output("|-|");
		while(!tempStack.isEmpty()){
			backPack.push(tempStack.pop());
		}
	}

	public static int getLife() {
		return life;
	}

	public static void setLife(int life) {
		CengMAN.life = life;
	}

	public static int getAtackDamage() {
		return atackDamage;
	}

	public static void setAtackDamage(int atackDamage) {
		CengMAN.atackDamage = atackDamage;
	}

	public Stack getBackPack() {
		return backPack;
	}

	public void setBackPack(Stack backPack) {
		this.backPack = backPack;
	}

	public Coordinat getCoordination() {
		return coordination;
	}

	public void setCoordination(Coordinat coordination) {
		this.coordination = coordination;
	}

	public int getRange() {
		return range;
	}

	public int getCreatingTime() {
		return creatingTime;
	}

	public int getCost() {
		return cost;
	}

	public void addBackpack() {
	}

	public void deleteBackpack() {
	}

	public void Move(int x, int y) {

	}

	public void atack() {
	}

	public void creatWall() {
	}

	public void feed() {
		// +lvl +health +atack
	}

	public void harvest() {
	}

	public String getName() {
		return name;

	}

	public void setName(String name) {
		this.name = name;
	}

	public int getLevel() {
		return level;
	}
}
