
public class Cement {
	private final int buildingCost=100;
	private final int creatingTime=1;
	private Coordinat cord;
	
	public Cement(int x , int y) {
		cord=new Coordinat(x,y);
	}
	public Coordinat getCord() {
		return cord;
	}
	public void setCord(Coordinat cord) {
		this.cord = cord;
	}
	public int getBuildingCost() {
		return buildingCost;
	}
	public int getCreatingTime() {
		return creatingTime;
	}
	
	
	
	
}
