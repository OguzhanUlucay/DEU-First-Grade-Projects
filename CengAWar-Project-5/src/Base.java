
public class Base {
	private int life;
	private int buildingCost;
	private int createTime;
	private Coordinat location;
	private boolean flag=false;
	public Base(int x, int y) {
		super();
		this.life = 1000;
		this.location = new Coordinat(x,y);
		
	}
	public boolean createCengMAN(){
			
		for (int i = -1; i < 2; i++) {
			
			for (int j = -1; j < 3; j++) {
				if(GameManagament.map[location.getX()+i][location.getY()+j][0].getClass().getName().equalsIgnoreCase("Food")){
					if(((Food)GameManagament.map[location.getX()+i][location.getY()+j][0]).getAmount()==50){
						GameManagament.map[location.getX()+i][location.getY()+j][0]=" ";
						flag=true;
						break;
						
					}
				}
				
			}
			if(flag==true){
				break;
			}
		}
			return flag;
		
	}
	public boolean createTree(){
		flag=false;
		for (int i = -1; i < 2; i++) {
			
			for (int j = -1; j < 3; j++) {
				if(GameManagament.map[location.getX()+i][location.getY()+j][0].getClass().getName().equalsIgnoreCase("Food")){
					if(((Food)GameManagament.map[location.getX()+i][location.getY()+j][0]).getAmount()==50){
					GameManagament.map[location.getX()+i][location.getY()+j][0]=" ";
					flag=true;
					break;
					}
				}
				
			}
			if(flag==true){
				break;
			}
		}
			return flag;
		
	}
	public Coordinat getLocation() {
		return location;
	}
	public void setLocation(Coordinat location) {
		this.location = location;
	}
	


	




}