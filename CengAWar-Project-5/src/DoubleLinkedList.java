
public class DoubleLinkedList {
	private Node tempParent = null;
	private Node head;
	private Node tail;
	private Node temp;
	private int counter;
	static boolean flag = false;

	public DoubleLinkedList() {
		head = null;
		tail = null;

	}

	public void add(Coordinat dataToAdd) {
		if (dataToAdd != null && head == null && tail == null) {
			Node newNode = new Node();
			newNode.setCoordinat(dataToAdd);
			head = newNode;
			tail = newNode;

		} else if (dataToAdd != null) {
			Node newNode = new Node();
			newNode.setCoordinat(dataToAdd);
			newNode.setPrevious(tail);
			tail.setNext(newNode);
			tail = newNode;

		}

	}

	public void add2(Node dataToAdd) {
		if (head == null && tail == null) {
			Node newNode = dataToAdd;
			head = newNode;
			tail = newNode;

		} else {
			Node newNode = dataToAdd;
			newNode.setPrevious(tail);
			tail.setNext(newNode);
			tail = newNode;

		}
		temp = tail;
	}

	public Coordinat path(Coordinat cord) {
		// genel döngü dýþýnda listi sýfýrla
			tempParent = temp;
		if ((tempParent.getCoordinat().getX() == cord.getX() && tempParent.getCoordinat().getY() == cord.getY())
				|| flag == true) {
			temp = temp.getParent();
			flag = true;
			if(GameManagament.map[tempParent.getCoordinat().getX()][tempParent.getCoordinat().getY()][0].equals(" ")){
			GameManagament.map[tempParent.getCoordinat().getX()][tempParent.getCoordinat().getY()][0] = ".";
			}
			
			return tempParent.getCoordinat();
		}

		else {
			temp = temp.getPrevious();
			return null;
		}
	}

	public Coordinat getDot(){
		Node tempForDot=tail;
		for (int i = 0; i <counter; i++) {
			tempForDot=tempForDot.getPrevious();
		}
		counter++;
		return tempForDot.coordinat;
		
	}

	public Node getHead() {
		return head;
	}

	public void setHead(Node head) {
		this.head = head;
	}

	public Node getTail() {
		return tail;
	}

	public void setTail(Node tail) {
		this.tail = tail;
	}

	public Node getTemp() {
		return temp;
	}

	public void setTemp(Node temp) {
		this.temp = temp;
	}

	public Coordinat peek() {
		return tail.getCoordinat();
	}

	public Node getTempParent() {
		return tempParent;
	}

	public void setTempParent(Node tempParent) {
		this.tempParent = tempParent;
	}

}
