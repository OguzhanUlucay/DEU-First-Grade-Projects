
public class Food {
	private int amount;
	private Coordinat cord;
	private final int maxLimit=50;
	
	public Food(int amount) {
		this.amount=amount;
	}

	public int getAmount() {
		return amount;
	}
	public void setAmount(int amount) {
		this.amount = amount;
	}

	public Coordinat getCord() {
		return cord;
	}
	public void setCord(Coordinat cord) {
		this.cord = cord;
	}

	public int getMaxLimit() {
		return maxLimit;
	}
	
	
	
	
}
