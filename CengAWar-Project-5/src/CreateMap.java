import java.awt.Color;
import java.awt.event.KeyListener;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.OutputStreamWriter;

import enigma.console.TextAttributes;
import enigma.core.Enigma;
import enigma.event.TextMouseEvent;
import enigma.event.TextMouseListener;

public class CreateMap {
	int targetX;
	int targetY;
	public TextMouseListener tmlis;
	public TextMouseListener tmlis1;
	public TextMouseListener tmlis2;

	public KeyListener klis;
	// ------ Standard variables for mouse and keyboard ------
	public int mousepr; // mouse pressed?
	public int mousex, mousey; // mouse text coords.
	public int keypr; // key pressed?
	public int rkey; // key (for press/release)
	// ----------------------------------------------------
	public static Object[][][] map = new Object[19][49][3];
	enigma.console.Console cn = Enigma.getConsole("Ceng-A-War", 220, 60, true);
	TextAttributes a1 = new TextAttributes(Color.LIGHT_GRAY, Color.black);
	TextAttributes a = new TextAttributes(Color.LIGHT_GRAY, Color.LIGHT_GRAY);
	int x = 3;
	int y = 5;

	public void mapTransfer() {
		BufferedReader bufferReader = null;
		try {
			String sCurrentLine;
			bufferReader = new BufferedReader(new FileReader("C:\\Users\\Anýl\\Desktop\\createmap.txt"));

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
					System.out.println(map[i][j][0]);
					x++;
				}
			}
			y++;
			x = 3;
		}
		cn.getTextWindow().setCursorPosition(5, 2);
		cn.getTextWindow().output("|O|");
		cn.getTextWindow().setCursorPosition(17, 2);
		cn.getTextWindow().output("|X|");
		x = 3;
		y = 5;
	}
	public static void writeFile() throws IOException {
		File fout = new File("C:\\Users\\Anýl\\Desktop\\createmap1.txt");
		FileOutputStream fos = new FileOutputStream(fout);
	 
		BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));
	 
		for (int i = 0; i < 19; i++) {
			for (int j = 0; j < 49; j++) {
				bw.write(((String) map[i][j][0]));
			}
			bw.newLine();
		}
	 
		bw.close();
	}
	CreateMap() throws InterruptedException {
		
		tmlis1 = new TextMouseListener() {
			public void mouseClicked(TextMouseEvent arg0) {
			}

			public void mousePressed(TextMouseEvent arg0) {
				if (mousepr == 0) {
					mousex = arg0.getX();
					mousey = arg0.getY();
					targetX = mousex - 3;
					targetY = mousey - 5;
					if (mousex > 3 && mousex < 51 && mousey > 5 && mousey < 23&&map[targetY][targetX][0] != "#") {
						map[targetY][targetX][0] = "#";
					}
					else if  (map[targetY][targetX][0] == "#"){
						map[targetY][targetX][0] = " ";
					}
//					else if(mousex >= 17 && mousex <= 19 && mousey ==2){
//						try {
//							writeFile();
//						} catch (IOException e) {
//							// TODO Auto-generated catch block
//							e.printStackTrace();
//						}
//					}
//					
				}
			}

			public void mouseReleased(TextMouseEvent arg0) {
			}
		};
		tmlis = new TextMouseListener() {
			public void mouseClicked(TextMouseEvent arg0) {
			}

			public void mousePressed(TextMouseEvent arg0) {
				if (mousepr == 0) {
					mousex = arg0.getX();
					mousey = arg0.getY();
					if (mousex >= 5 && mousex <= 7 && mousey == 2) {

						cn.getTextWindow().addTextMouseListener(tmlis1);

					}
					mousepr = 0;
				}
			}

			public void mouseReleased(TextMouseEvent arg0) {
			}
		};
		mapTransfer();
		while (true) {
			display();
			cn.getTextWindow().addTextMouseListener(tmlis);
			Thread.sleep(20);
		}
	}
}
