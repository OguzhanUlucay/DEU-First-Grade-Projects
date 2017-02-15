import enigma.core.Enigma;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import enigma.console.TextAttributes;
import java.awt.Color;
import java.util.*;
public class Input {
	public enigma.console.Console cn = Enigma.getConsole("Mouse and Keyboard");
	public KeyListener klis;
	
	public static String enterString = "";
	
	Input() throws Exception { // --- Contructor

		klis = new KeyListener() {
			public void keyTyped(KeyEvent e) {
			}

			public void keyPressed(KeyEvent e) {
				if(e.getKeyCode() ==KeyEvent.VK_BACK_SPACE)//backspace
				{
				
				if(enterString.length()>0){
				enterString = enterString.substring(0,enterString.length()-1);
				}
				}
				else if(e.getKeyCode() ==KeyEvent.VK_ENTER)//enter
				{
					enterString=enterString.toLowerCase();
					ScreenTest.getInfo().parsing(enterString,cn);
				
				}
				else if((e.getKeyCode()>64 && e.getKeyCode()<91)||(e.getKeyCode()>96 && e.getKeyCode()<123)||
						(e.getKeyCode()>47 && e.getKeyCode()<58 )||e.getKeyCode()==32||e.getKeyCode()==45)
				{
			
				enterString += e.getKeyChar();
				
				}
				
				ScreenTest.cn.getTextWindow().setCursorPosition(0, 20);
				ScreenTest.cn.getTextWindow().output("                                                  ");
				ScreenTest.cn.getTextWindow().setCursorPosition(0, 20);
				ScreenTest.cn.getTextWindow().output("Command > " + enterString);
				

			}

			public void keyReleased(KeyEvent e) {
			}
			
		};
		cn.getTextWindow().addKeyListener(klis);
	
	}

	public String getEnterString() {
		return enterString;
	}
	


}
