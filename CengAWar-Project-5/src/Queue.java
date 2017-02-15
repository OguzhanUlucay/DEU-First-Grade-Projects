
public class Queue {

	private int rear;
	private int front;
	private Node[] elements;

	public Queue(int capacity) {
		elements = new Node[capacity];
		rear = -1;
		front = 0;
	}

	public void enqueue(Node data) {
		if (isFull()) {
			System.out.println("Queue Overflow!");
		} else {
			rear++;
			elements[rear] = data;
		}

	}

	public Node dequeue() {

		if (isEmpty()) {
			System.out.println("Queue is Empty");
			return null;
		} else {
			Node data = elements[front];
			elements[front] = null;
			front++;
			return data;
		}
	}

	public Node peek() {
		if (isEmpty()) {
			System.out.println("Queue is Empty");
			return null;
		} else {
			return elements[front];
		}

	}

	public boolean isFull() {

		return (rear + 1 == elements.length);
	}

	public boolean isEmpty() {
		return (front > rear);
	}

	public int size() {

		return rear - front + 1;
	}
}
