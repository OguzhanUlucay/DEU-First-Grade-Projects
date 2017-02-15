import java.awt.Color;
import java.awt.event.KeyListener;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import enigma.core.Enigma;
import enigma.event.TextMouseEvent;
import enigma.event.TextMouseListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import enigma.console.TextAttributes;
import java.awt.Color;
import enigma.console.TextAttributes;
import enigma.core.Enigma;
import enigma.event.TextMouseListener;
import java.util.*;

public class GameManagament {
	public static enigma.console.Console cn = Enigma.getConsole("Ceng-A-War", 220, 60, true);
	public TextMouseListener tmlis;
	public KeyListener klis;

	// ------ Standard variables for mouse and keyboard ------
	public int mousepr; // mouse pressed?
	public int mousex, mousey; // mouse text coords.
	public int keypr; // key pressed?
	public int rkey; // key (for press/release)
	// ----------------------------------------------------

	// variables
	public static Object[][][] map = new Object[19][49][3];
	private BufferedReader bufferReader;
	Stack s = new Stack(150);
	CengMAN[] cng1 = new CengMAN[100];
	CengMAN[] cng2 = new CengMAN[100];
	Tree[] t1 = new Tree[100];
	Tree[] t2 = new Tree[100];
	Food[] f=new Food[150];
	TextAttributes a = new TextAttributes(Color.LIGHT_GRAY, Color.LIGHT_GRAY);
	TextAttributes a1 = new TextAttributes(Color.LIGHT_GRAY, Color.black);
	int x = 3;
	int y = 5;
	int splitSecond = 0;
	int second = 0;
	int min = 0;
	int hour = 0;
	int day = 0;
	int counter = 0;
	public Queue Q;
	private Node root;// For Pathfinding
	private boolean flagForPath;// For Pathfinding
	private boolean moveConfirmed = false;// For Pathfinding
	private boolean extractConfirmed=false;
	private boolean isCengman = false;
	private boolean isBase = false;
	private boolean isNull = true;
	private DoubleLinkedList p;// For Pathfinding
	private DoubleLinkedList coordinatsOfPath;// For Pathfinding
	private int targetX;// For Pathfinding
	private int targetY;// For Pathfinding
	private Base[] base = new Base[2];
	private CengMAN tempCengMAN;
	private boolean activeunitflag = false;
	private int activeUnit = 0;
	private int foodCounter=0;
	private int treecounter = 0;
	private int cengmanCounter=0;
	private int treex;
	private int treey;
	private Base tempBase;
	private int tempTime;
	private boolean modC = false;
	private boolean modT=false;
	
	public void activeUnit() {
		cn.setTextAttributes(a1);
		if (tempCengMAN != null) {
			cn.getTextWindow().setCursorPosition(61, 11);
			cn.getTextWindow().output("Name:" + cng1[activeUnit].getName());// active
																			// unit
																			// name
			cn.getTextWindow().setCursorPosition(61, 12);
			cn.getTextWindow().output("Life:" + cng1[activeUnit].getLife());// active
																			// unit
																			// life
			cn.getTextWindow().setCursorPosition(61, 13);
			cn.getTextWindow().output("Level:" + cng1[activeUnit].getLevel());// active
																				// unit
																				// level
		}/*else {
			cn.getTextWindow().setCursorPosition(61, 11);
			cn.getTextWindow().output("Name:     ");// active
													// unit
													// name
			cn.getTextWindow().setCursorPosition(61, 12);
			cn.getTextWindow().output("Life:    ");// active
													// unit
													// life
			cn.getTextWindow().setCursorPosition(61, 13);
			cn.getTextWindow().output("Level:    ");// active
													// unit
													// level
		}*/
		
		if (tempCengMAN != null) {
			tempCengMAN.displayInventory();
		}

		cn.getTextWindow().setCursorPosition(55, 20);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(55, 21);
		cn.getTextWindow().output("|G|");
		cn.getTextWindow().setCursorPosition(55, 22);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(61, 20);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(61, 21);
		cn.getTextWindow().output("|E|");
		cn.getTextWindow().setCursorPosition(61, 22);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(67, 20);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(67, 21);
		cn.getTextWindow().output("|W|");
		cn.getTextWindow().setCursorPosition(67, 22);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(72, 20);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(72, 21);
		cn.getTextWindow().output("|F|");
		cn.getTextWindow().setCursorPosition(72, 22);
		cn.getTextWindow().output("---");
	}

	public void mapTransfer() {
		try {
			String sCurrentLine;
			bufferReader = new BufferedReader(new FileReader("C:\\Users\\oguzh\\workspace\\CENG-a-War\\map.txt"));

			for (int i = 0; i < 19; i++) {
				sCurrentLine = bufferReader.readLine();
				for (int j = 0; j < 49; j++) {
					map[i][j][0] = sCurrentLine.substring(j, j + 1);
				}
			}

		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				if (bufferReader != null)
					bufferReader.close();
			} catch (IOException ex) {
				ex.printStackTrace();
			}
		}
	}

	public void display() {
		//int fakey = 0;
		cn.setTextAttributes(a1);
		for (int i = 0; i < map.length; i++) {
			for (int j = 0; j < map[1].length; j++) {
				if (map[i][j][0].equals("#")) {

					cn.getTextWindow().setCursorPosition(x, y);
					cn.setTextAttributes(a);
					System.out.println(map[i][j][0]);
					cn.setTextAttributes(a1);
					x++;
				} else {
					cn.setTextAttributes(a1);
					cn.getTextWindow().setCursorPosition(x, y);
					if (map[i][j][0].getClass().getName().equalsIgnoreCase("CengMAN")) {
						System.out.println(((CengMAN) map[i][j][0]).getLevel());
					} else if (map[i][j][0].getClass().getName().equalsIgnoreCase("Base")) {
						if (j == ((((Base) map[i][j][0]).getLocation().getY()))) {
							System.out.println("[");
						} else {
							System.out.println("]");
						}
					}else if (map[i][j][0].getClass().getName().equalsIgnoreCase("Food")) {
						System.out.println("F");
					} else if (map[i][j][0].getClass().getName().equalsIgnoreCase("Tree")) {
						System.out.println("T");
					}
					else {
						System.out.println(map[i][j][0]);

					}
					x++;
				}
			}
			y++;
			x = 3;
			activeUnit();
			//fakey = y;
			//y = fakey;
		}
		
		cn.getTextWindow().setCursorPosition(3, 0);
		cn.getTextWindow().output("                   -----------------");
		cn.getTextWindow().setCursorPosition(3, 1);
		cn.getTextWindow().output("Production Queue ->                 <-");
		cn.getTextWindow().setCursorPosition(3, 2);
		cn.getTextWindow().output("                   -----------------");
		cn.getTextWindow().setCursorPosition(3, 3);
		cn.getTextWindow().output("Base Life : ");
		cn.getTextWindow().setCursorPosition(15, 3);
		cn.getTextWindow().output("1000");// base life method
		cn.getTextWindow().setCursorPosition(22, 3);
		cn.getTextWindow().output("Enemy Base Life : ");
		cn.getTextWindow().setCursorPosition(40, 3);
		cn.getTextWindow().output("1000");// enemybase life method
		cn.getTextWindow().setCursorPosition(55, 2);
		cn.getTextWindow().output("---");
		
		cn.getTextWindow().setCursorPosition(55, 3);
		cn.getTextWindow().output("|T|");
		cn.getTextWindow().setCursorPosition(55, 4);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(61, 2);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(61, 3);
		cn.getTextWindow().output("|C|");
		cn.getTextWindow().setCursorPosition(61, 4);
		
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(67, 2);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(67, 3);
		cn.getTextWindow().output("|W|");
		cn.getTextWindow().setCursorPosition(67, 4);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(72, 2);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(72, 3);
		cn.getTextWindow().output("|R|");
		cn.getTextWindow().setCursorPosition(72, 4);
		cn.getTextWindow().output("---");
		cn.getTextWindow().setCursorPosition(60, 1);
		cn.getTextWindow().output("|Base mods|");
		cn.getTextWindow().setCursorPosition(61, 10);
		cn.getTextWindow().output("Active Unit");
	}

	public void generateBase() {
		Random rnd = new Random();

		do {
			x = rnd.nextInt(3) + 1;
			y = rnd.nextInt(9) + 1;
		} while (map[x][y][0].equals("#") && map[x][y + 1][0].equals("#"));

		base[0] = new Base(x, y);
		map[x][y][0] = base[0];
		map[x][y + 1][0] = base[0];
		f[foodCounter]=new Food(50);
		map[x+1][y][0]=f[foodCounter];
		f[foodCounter]=new Food(50);
		map[x+1][y+2][0]=f[foodCounter];
		
	}

	public void path() {
		Node[][] points = new Node[19][49];
		Node current;

		for (int i = 0; i < 19; i++) {

			for (int j = 0; j < 49; j++) {
				points[i][j] = new Node();
				if (!map[i][j][0].equals(" ")) {
					points[i][j].setData(-1);
				} else {
					points[i][j].setData(9999);
					points[i][j].setParent(null);// link=parent
				}
			}

		}

		Q = new Queue(10000);
		root.setData(0);

		Q.enqueue(root);
		while (!Q.isEmpty() && targetX != 0 && targetY != 0) {

			current = Q.peek();

			int currentCoordX = current.getCoordinat().getX();
			int currentCoordY = current.getCoordinat().getY();
			if(map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Food")||
					map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Cement")
					||map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Tree")){
				points[targetX][targetY].setData(9999);
			}
			if (targetX == currentCoordX && targetY == currentCoordY) {
				break;
			}

			if ((int) points[currentCoordX][currentCoordY].getData() != 9998) {

				points[root.getCoordinat().getX()][root.getCoordinat().getY()].setData(9998);

				if ((int) points[currentCoordX + 1][currentCoordY].getData() == 9999) {// aþaðý
					points[currentCoordX + 1][currentCoordY].setData((int) current.getData() + 1);
					points[currentCoordX + 1][currentCoordY].setParent(current);
					points[currentCoordX + 1][currentCoordY]
							.setCoordinat(new Coordinat(currentCoordX + 1, currentCoordY));
					Q.enqueue(points[currentCoordX + 1][currentCoordY]);
					p.add2(points[currentCoordX + 1][currentCoordY]);

				}
				if ((int) points[currentCoordX][currentCoordY + 1].getData() == 9999) {// sað

					points[currentCoordX][currentCoordY + 1].setData((int) current.getData() + 1);
					points[currentCoordX][currentCoordY + 1].setParent(current);
					points[currentCoordX][currentCoordY + 1]
							.setCoordinat(new Coordinat(currentCoordX, currentCoordY + 1));
					Q.enqueue(points[currentCoordX][currentCoordY + 1]);
					p.add2(points[currentCoordX][currentCoordY + 1]);

				}
				if ((int) points[currentCoordX - 1][currentCoordY].getData() == 9999) {// yukarý
					points[currentCoordX - 1][currentCoordY].setData((int) current.getData() + 1);
					points[currentCoordX - 1][currentCoordY].setParent(current);
					points[currentCoordX - 1][currentCoordY]
							.setCoordinat(new Coordinat(currentCoordX - 1, currentCoordY));
					Q.enqueue(points[currentCoordX - 1][currentCoordY]);
					p.add2(points[currentCoordX - 1][currentCoordY]);

				}
				if ((int) points[currentCoordX][currentCoordY - 1].getData() == 9999) {//sol
					points[currentCoordX][currentCoordY - 1].setData((int) current.getData() + 1);
					points[currentCoordX][currentCoordY - 1].setParent(current);
					points[currentCoordX][currentCoordY - 1]
							.setCoordinat(new Coordinat(currentCoordX, currentCoordY - 1));
					Q.enqueue(points[currentCoordX][currentCoordY - 1]);
					p.add2(points[currentCoordX][currentCoordY - 1]);

				}

			}

			Q.peek().setData(9998);
			Q.dequeue();
		}

	}

	public void unitMove(int i) throws InterruptedException {// sonradan eklenen
																// kýsým
		
		if (isNull == false) {
			if (!cng1[i].getCoordination().equals(coordinatsOfPath.getHead().getNext().getCoordinat())) {
				map[cng1[i].getCoordination().getX()][cng1[i].getCoordination().getY()][0] = " ";

				cng1[i].setCoordination(coordinatsOfPath.getDot());
				map[cng1[i].getCoordination().getX()][cng1[i].getCoordination().getY()][0] = cng1[i];
				
			}else{
			if(map[coordinatsOfPath.getHead().getCoordinat().getX()][coordinatsOfPath.getHead().getCoordinat().getY()][0].getClass().getName().equalsIgnoreCase("Food")||
					map[coordinatsOfPath.getHead().getCoordinat().getX()][coordinatsOfPath.getHead().getCoordinat().getY()][0].getClass().getName().equalsIgnoreCase("Cement")){	
			cng1[i].fillInventory(map[coordinatsOfPath.getHead().getCoordinat().getX()][coordinatsOfPath.getHead().getCoordinat().getY()][0]);
			map[coordinatsOfPath.getHead().getCoordinat().getX()][coordinatsOfPath.getHead().getCoordinat().getY()][0]=" ";
			}
			else if(map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Tree")){
				f[foodCounter]=new Food(((Tree)map[targetX][targetY][0]).getFood());
				cng1[i].fillInventory(f[foodCounter]);
				foodCounter++;
			}
			isNull=true;
			coordinatsOfPath = new DoubleLinkedList();
			flagForPath = false;
			isCengman = false;
			moveConfirmed = false;
			}
		} else {
			if (!cng1[i].getCoordination().equals(coordinatsOfPath.getHead().getCoordinat())) {
				map[cng1[i].getCoordination().getX()][cng1[i].getCoordination().getY()][0] = " ";

				cng1[i].setCoordination(coordinatsOfPath.getDot());
				map[cng1[i].getCoordination().getX()][cng1[i].getCoordination().getY()][0] = cng1[i];
				

			}
			else{
				coordinatsOfPath = new DoubleLinkedList();
				flagForPath = false;
				isCengman = false;
				moveConfirmed = false;
			}
		}
		
		

	}

	public void produceCengMAN(int a) {
		if (second == 8 + tempTime||a==1) {
			boolean flag=false;
			for (int i = -1; i < 2; i++) {
				
				for (int j = -1; j < 3; j++) {
					if(map[base[0].getLocation().getX()+i][base[0].getLocation().getY()+j][0].equals(" ")){
						cng1[cengmanCounter] = new CengMAN(base[0].getLocation().getX()+i,base[0].getLocation().getY()+j);
						map[base[0].getLocation().getX()+i][base[0].getLocation().getY()+j][0]=cng1[cengmanCounter];
						flag=true;
						break;
					}
					
				}
				if(flag==true){
					break;
				}
			}
			
			cengmanCounter++;
			isBase = false;
			modC = false;
		}
	}
	public void produceTree(int a){
		Random rnd=new Random();
		if (second == 1 + tempTime||a==1) {
			do {
				treex = rnd.nextInt(19);
				treey = rnd.nextInt(49);
			} while (!map[treex][treey][0].equals(" "));
			t1[treecounter] = new Tree(treex, treey);
			map[treex][treey][0] = t1[treecounter];
			treecounter++;
			isBase = false;
			modT = false;
		}
	}

	GameManagament() throws InterruptedException {
		
		int px = 61, py = 8;
		mapTransfer();
		
		
		generateBase();
		produceCengMAN(1);
		produceCengMAN(1);
		produceCengMAN(1);
		produceTree(1);
		produceTree(1);
		produceTree(1);
		coordinatsOfPath = new DoubleLinkedList();
		
		while (true) {
			cn.getTextWindow().addTextMouseListener(tmlis);//yoktu
			x = 3;
			y = 5;
			display();

			// ------ Standard code for mouse and keyboard ------ Do not change
			tmlis = new TextMouseListener() {
				public void mouseClicked(TextMouseEvent arg0) {
					mousepr = 0;//yoktu
				}

				public void mousePressed(TextMouseEvent arg0) {
					if (mousepr == 0) {//0 dý

						mousex = arg0.getY();// satýr
						mousey = arg0.getX();// sütun
						// cn.getTextWindow().output(mousex, mousey, '#');
						if ((mousex > 5 && mousey > 3) && (mousex < 24 && mousey < 52)
								&& (map[mousex - 5][mousey - 3][0] instanceof CengMAN)) {// sonrada
																							// eklenen
							for (int i = 0; i < cng1.length; i++) {
								if (cng1[i] == map[mousex - 5][mousey - 3][0]) {
									activeUnit = i;
								}

							}
							tempCengMAN = (CengMAN) map[mousex - 5][mousey - 3][0];
							activeunitflag = true;
							isCengman = true;
						}
						if ((mousex > 5 && mousey > 3) && (mousex < 24 && mousey < 52)
								&& (map[mousex - 5][mousey - 3][0] instanceof Base)) {// sonrada
																						// eklenen
							tempBase = (Base) map[mousex - 5][mousey - 3][0];
							isBase = true;
						}
						if ((mousey >= 54 && mousey <= 56) && (mousex >= 2 && mousex <= 4)&&isBase==true) {
							//t
							modT = true;
							if (tempBase.createTree() == true) {
								tempTime = second;
							}
							
						}
						if ((mousey >= 60 && mousex >= 2) && (mousey <= 63 && mousex <= 4) && isBase == true) {
							// c
							modC = true;
							if (tempBase.createCengMAN() == true) {
								tempTime = second;
							}
							
						}
						if (mousex >= 66 && mousex <= 68 && mousey >= 2 && mousey <= 4) {
							// w
						}
						if (mousex >= 71 && mousex <= 73 && mousey >= 2 && mousey <= 4) {
							// r
						}

						if ((mousex >= 20 && mousey >= 54) && (mousey <= 56 && mousex <= 22) && isCengman == true) {// burada
																													// deðiþiklik
																													// var
							// g
							root = new Node(0);
							root.setCoordinat(tempCengMAN.getCoordination());
							flagForPath = true;
						} else if (flagForPath == true) {
							targetX = mousex - 5;
							targetY = mousey - 3;
							if (map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Food")||
									map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Cement")||
									map[targetX][targetY][0].getClass().getName().equalsIgnoreCase("Tree")
									) {
								isNull = false;

							} 
							Coordinat targetCoord = new Coordinat(targetX, targetY);
							p = new DoubleLinkedList();
							path();

							coordinatsOfPath.add(p.path(targetCoord));
							while (!p.getHead().getParent().equals(p.getTempParent())) {
								coordinatsOfPath.add(p.path(targetCoord));
								//map[targetX][targetY][0] = "o";
							}

							moveConfirmed = true;
							flagForPath = false;

						}
						if (((mousey >= 60 && mousex >= 20)&&(mousey <= 62 &&mousex <= 22)&& isCengman == true)||extractConfirmed==true) {
							// e
							extractConfirmed=true;
							if((mousex-5>=cng1[activeUnit].getCoordination().getX()-1&&mousex-5<=1+cng1[activeUnit].getCoordination().getX())&&
									(mousey-3>=cng1[activeUnit].getCoordination().getY()-1&&mousey-3<=1+cng1[activeUnit].getCoordination().getY())
									){
								if(map[mousex-5][mousey-3][0].equals(" ")){
									map[mousex-5][mousey-3][0]=cng1[activeUnit].extractInventory();

								}
								extractConfirmed=false;
							}
							isCengman=false;
							
						}
						if (mousex >= 66 && mousex <= 68 && mousey >= 20 && mousey <= 22) {
							// w
						}
						if (mousex >= 71 && mousex <= 73 && mousey >= 20 && mousey <= 22) {
							// f
						}

						mousepr = 0;
					}
				}

				public void mouseReleased(TextMouseEvent arg0) {
				}
			};

		
			if (modC == true) {
				produceCengMAN(0);
			}
			if (modT == true) {
				produceTree(0);
			}
			cn.getTextWindow().addTextMouseListener(tmlis);

			cn.getTextWindow().setCursorPosition(60, 0);
			cn.getTextWindow().output("Time: " + hour + ":" + min + ":" + second + " |Day:" + day + "  |");
			splitSecond++;
			Thread.sleep(20);
			if (splitSecond % 30 == 0) {
				second++;
				if (treecounter > 0) {
					for (int i = 0; i < treecounter; i++) {
						t1[i].generateFood();
					}
				}
				if (moveConfirmed == true) {// adým adým hareket etme kýsmý
					unitMove(activeUnit);
				}
			}
			if (second == 60) {
				min++;
				second = 0;
			}

			if (min == 60) {
				min = 0;
				hour++;
			}
			if (hour == 24) {
				hour = 0;
				day++;
			}
		}
	}

}