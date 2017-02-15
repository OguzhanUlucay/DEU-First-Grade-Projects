import java.util.*;

import enigma.core.Enigma;
import java.text.DecimalFormat;
public class ScreenTest {
	static GameManagement management;
	static enigma.console.Console cn = Enigma.getConsole("Tamagotchi", 180, 50, false);
	static int turn = 1;
	static int day = 1;
	static Child children;
	private static String applicationtype=null;
	private static String applicationtype2=null;
	private static String applicationtype3=null;
	static boolean applicationcontrol = false;
	static boolean applicationcontrol2 = false;
	static boolean applicationcontrol3 = false;
	static DecimalFormat df=new DecimalFormat("#,##");
	public static void main(String[] args) throws Exception {
		Input keylist = new Input();
		management = new GameManagement();

		Calendar rightnow = Calendar.getInstance();
		long offset = rightnow.get(Calendar.ZONE_OFFSET) + rightnow.get(Calendar.DST_OFFSET);
		long time1 = (rightnow.getTimeInMillis() + offset);

		while (true) {
			cn.getTextWindow().setCursorPosition(0, 0);
			for (int i = 0; i < 20; i++) {          
				System.out.println("                                                                                                                                   ");
			}
			cn.getTextWindow().setCursorPosition(0, 0);
			System.out.print("Day : " + day +" ");
			System.out.print("Turn: " + turn+" ");

			management.Screen(cn);

			Screen2();
			
			System.out.println();
			for(int i=0;i<management.getCountWorkers();i++){
				management.workerTunneltime(i);
			}
			management.tunnelHappiness();
			management.Screen_Child(cn);
			
			rightnow = Calendar.getInstance();
			offset = rightnow.get(Calendar.ZONE_OFFSET) + rightnow.get(Calendar.DST_OFFSET);
			long time2 = (rightnow.getTimeInMillis() + offset);
			time2=time2+1000;
				if (time2 - time1 >= 2000) {
					turn++;
					management.MissingChildCalculate();
					management.carerJobinvoker();
					management.discreaseChild();
					if (turn == 50) {
						// end of the day avarage happiness deðeri alýnacak.
						day++;
						turn = 0;
					}
					if (management.getCurrentAVGH() > 20 && ScreenTest.turn == 49) {
						Random rnd = new Random();
						
						int randomnumber = rnd.nextInt(100) + 1;
						randomnumber=10;
						int randomnumber2 = rnd.nextInt(100) + 1;
						randomnumber2=30;
						int randomnumber3 = rnd.nextInt(100) + 1;
						if (randomnumber > 0 && randomnumber < 20) {
							cn.getTextWindow().setCursorPosition(0, 5);						
							applicationcontrol = true;
							applicationtype = "ch";

							management.createMember(applicationtype);
						}
						if (randomnumber2 > 20 && randomnumber2 < 40) {
							cn.getTextWindow().setCursorPosition(0, 6);
							applicationcontrol2 = true;
							applicationtype2 = "wr";
						}
						if (randomnumber3 > 40 && randomnumber3 < 60) {
							cn.getTextWindow().setCursorPosition(0, 7);
							applicationcontrol3 = true;
							applicationtype3 = "cr";
						}
					}
					if (turn == 11&&(applicationcontrol==true||applicationcontrol2==true||applicationcontrol3==true)) {
						applicationtype = null;
						applicationcontrol = false;
						applicationcontrol2 = false;
						applicationcontrol3 = false;
						if(management.isIs_accepted()==false){
							management.deleteMemeber();
							}
						else{
							management.setIs_accepted(false);
							
						}
						
					
					}
					time1 = time2;
					
				}
				else{
					Thread.sleep(2000);
				}
			
		}
	}
	public static void Screen2(){
		cn.getTextWindow().setCursorPosition(70, 1);
		System.out.println("---Supplies---");
		cn.getTextWindow().setCursorPosition(70, 2);
		System.out.println("Food: " +df.format(management.getGameFood()));
		cn.getTextWindow().setCursorPosition(70, 3);
		System.out.println("Toy: " +df.format(management.getGameToy()));
		cn.getTextWindow().setCursorPosition(70, 4);
		System.out.println("Hygiene: "+df.format(management.getGameHygiene()));
	}
	public static GameManagement getInfo() {
		return management;
	}
}

