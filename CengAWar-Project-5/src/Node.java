
public class Node {

	private Object data;//distance
	private Node next;
	private Node previous;
	
	public Coordinat coordinat; 
	private Node parent;
	public Node(Object dataToAdd) {
		data = dataToAdd;
		next = null;
		previous=null;
	}
	public Node(){
		next = null;
		previous=null;
	}
	public Coordinat getCoordinat() {
		return coordinat;
	}

	public void setCoordinat(Coordinat coordinat) {
		this.coordinat = coordinat;
	}

	public Object getData() {
		return data;
	}
	public void setData(Object data) {
		this.data = data;
	}

	public Node getNext() {
		return next;
	}

	public void setNext(Node next) {
		this.next = next;
	}

	public Node getPrevious() {
		return previous;
	}

	public void setPrevious(Node previous) {
		this.previous = previous;
	}

	public Node getParent() {
		return parent;
	}

	public void setParent(Node parent) {
		this.parent = parent;
	}
	

}
