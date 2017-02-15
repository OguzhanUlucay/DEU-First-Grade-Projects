import java.awt.Color;
import java.awt.event.KeyListener;

import enigma.console.TextAttributes;
import enigma.core.Enigma;
import enigma.event.TextMouseEvent;
import enigma.event.TextMouseListener;

public class Display {
	public boolean flag;
	public TextMouseListener tmlis;
	public KeyListener klis;

	// ------ Standard variables for mouse and keyboard ------
	public int mousepr; // mouse pressed?
	public int mousex, mousey; // mouse text coords.
	public int keypr; // key pressed?
	public int rkey; // key (for press/release)
	// ----------------------------------------------------

	public void Game() throws InterruptedException {
		GameManagament g = new GameManagament();
	}

	Display() throws InterruptedException {
		enigma.console.Console cn = Enigma.getConsole("Ceng-A-War", 220, 60, true);
		tmlis = new TextMouseListener() {
			public void mouseClicked(TextMouseEvent arg0) {
				mousepr = 1;

			}

			public void mousePressed(TextMouseEvent arg0) {
				if (mousepr == 1) {
					mousex = arg0.getX();// satır
					mousey = arg0.getY();// sütun
					if (mousex >= 130 && mousex <= 170 && mousey >= 10 && mousey <= 15) {
						for (int i = 0; i < 60; i++) {
							cn.getTextWindow().setCursorPosition(0, i);
							cn.getTextWindow().output(
									"                                                                                                                                                                                                                            ");

						}
						flag = false;
						mousepr = 0;
					}
				}
			}

			public void mouseReleased(TextMouseEvent arg0) {

			}
		};

		int y = 0;

		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("+++++,               @##;            #;++#++++++; +  +++  +   ++++++++++++++        ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("++++              + #####      .,  .#+++   ++ ++#+  ++++++  ++++++++++   +          ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("+#++##          .,  #####,         +  ##+#+#+      ++++++++++++++ ++++++            ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("+#+#+++   +    @  +#######    .,  + +++ + #++++ +++##++++++++++++++++               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("++####+;  @    @   ########      .#   + #+ +++#+#++++++++++++++                     ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("++++#+#+; @   #    ########:@      ++#+ +##+##++++++++++++++++++++#++               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("++#+++++# @  +#  +########+:+,  .#,;####+++++ ###+++++++++++++                      ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("+++#+###++#+   ++#+#########@   #  # ++++##+###+#++++++++++++ +++                   ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("++++#+ #+#+++++ + #+#######;#,@ +# +# +++ +++###++++++ ++++                         ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("##++ ##+++ +++++#+######+##+;   +#+# #+  #++++#+#++++++                             ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("+##+#+########### #++####++#######+#++# +##+++++                                    ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output(" +#+#+#+##++#########++#######+#+##++###+++                                         ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("; +++++++++########+##+#  +++####+++#++#++  +                                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     #++###########++#####++##+#+###+                                               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("    +#@##############+######+#+###                                                  ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("    + #################+##########                                                  ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      @+##########+++#########+##+                                                  ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      ##############+@############@.;                                               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      ############################++                                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      ######@@######++############++                                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     ++####@  ###################+++                                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     ######@  @############+#####++#                                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     #+###@    @################+++@#                                               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     #####@@;  +###################++,                                              ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     #+++###; #######+############++                                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      ##+#+   @##################+#+                                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      #++##   @##################+ #++;                                             ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      #++##  +@######+######+###+##+++                                              ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       +##@  # ######+######+##### ##++     +                                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       ###@; #+######@##########+# ##++#+ .@                                        ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       @##@; ++#################+++#.#++  +#                                        ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       @###  ++##################+##,  # +@                                         ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       #++#@;#++####################,;,+@ #                                         ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       ###+#+######################+,  @  ##,                                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       ####+##@@#################+#+    # #++                                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("        ### @#+####################++  #.;.@#+;                                     ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("            +######+#############+##@  #   .@+++                                    ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("           ##+##+##############+#+++@,       @++#                                   ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("          .@####+++############+#+++#,        #++#+;                                ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("         +## ###++#############+#+# +,          #+#                                 ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("          +  +#+#+##+#########++++#,+            #+#+                               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("        +    ++#++###++# #####+#+##,@             ###                               ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("       +      #++++++### ####+##++# #+            .###;                             ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      +;      #++++##+#  @###+++#+#  +;             ##+;                            ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("      #       #+++++###  ####++++##  #;              #+#;                           ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("     #         +#++++#+   ###+#++#+# #                #++;.;                        ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("               +++++++#; #++++++++++;                 .+++,                         ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("               #++++++#; #+#++++++#,                   .#++,;                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("               #++++++#  ++++++++#                      .#+#                        ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("               +++++++# #++++++++;                        + +                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("                ++++#++,#+++++++;                           +#                      ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("                +++++++.+++++++                              +#                     ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("                +++++++ +++++++                               +                    ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("                ++++++ #+++++#                                                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("                ++++++ +++++#                                                       ");
		cn.getTextWindow().setCursorPosition(0, y);
		y++;
		cn.getTextWindow()
				.output("                 +++++++++++;                                                       ");

		cn.getTextWindow().setCursorPosition(20, 58);
		cn.getTextWindow().output(
				"        ____________________________________________________________________________________________________________________________________________________________________________________________________________________         ");
		cn.getTextWindow().setCursorPosition(20, 59);
		cn.getTextWindow().output(
				"_______/                                                                                                                           ");

		cn.getTextWindow().setCursorPosition(100, 2);
		cn.getTextWindow()
				.output("_________                                    _____              __      __      __________ ");
		cn.getTextWindow().setCursorPosition(100, 3);
		cn.getTextWindow().output(
				"\\_   ___ \\  ____   ____   ____              /  _  \\            /  \\    /  _____ \\______   \\");
		cn.getTextWindow().setCursorPosition(100, 4);
		cn.getTextWindow().output(
				"/    \\  \\/_/ __ \\ /    \\ / ___\\    ______  /  /_\\  \\    ______ \\   \\/\\/   \\__  \\ |       _/");
		cn.getTextWindow().setCursorPosition(100, 5);
		cn.getTextWindow().output(
				"\\     \\___\\  ___/|   |  / /_/  >  /_____/ /    |    \\  /_____/  \\        / / __ \\|    |   \\");
		cn.getTextWindow().setCursorPosition(100, 6);
		cn.getTextWindow().output(
				" \\______  /\\___  |___|  \\___  /           \\____|__  /            \\__/\\  / (____  |____|_  /");
		cn.getTextWindow().setCursorPosition(100, 7);
		cn.getTextWindow().output(
				"        \\/     \\/     \\/_____/                    \\/                  \\/       \\/       \\/");

		cn.getTextWindow().setCursorPosition(130, 10);
		cn.getTextWindow().output(" _________.__                ");
		cn.getTextWindow().setCursorPosition(130, 11);
		cn.getTextWindow().output(" \\______  \\  | _____  ___.__.");
		cn.getTextWindow().setCursorPosition(130, 12);
		cn.getTextWindow().output(" |     ___/  | \\__  \\<   |  |");
		cn.getTextWindow().setCursorPosition(130, 13);
		cn.getTextWindow().output(" |    |   |  |__/ __ \\\\___  |");
		cn.getTextWindow().setCursorPosition(130, 14);
		cn.getTextWindow().output(" |____|   |____(____  / ____|");
		cn.getTextWindow().setCursorPosition(130, 15);
		cn.getTextWindow().output("                    \\/\\/    ");

		cn.getTextWindow().setCursorPosition(130, 18);
		cn.getTextWindow().output(" _________                   ");
		cn.getTextWindow().setCursorPosition(130, 19);
		cn.getTextWindow().output(" /   _____/____ ___  __ ____  ");
		cn.getTextWindow().setCursorPosition(130, 20);
		cn.getTextWindow().output(" \\_____  \\\\__  \\\\  \\/ // __ \\ ");
		cn.getTextWindow().setCursorPosition(130, 21);
		cn.getTextWindow().output(" /        \\/ __ \\\\   /\\  ___/ ");
		cn.getTextWindow().setCursorPosition(130, 22);
		cn.getTextWindow().output(" /_______ (____  /\\_/  \\___  >");
		cn.getTextWindow().setCursorPosition(130, 23);
		cn.getTextWindow().output("         \\/    \\/          \\/ ");

		cn.getTextWindow().setCursorPosition(130, 26);
		cn.getTextWindow().output(" .__                    .___");
		cn.getTextWindow().setCursorPosition(130, 27);
		cn.getTextWindow().output(" |  |   _________     __| _/");
		cn.getTextWindow().setCursorPosition(130, 28);
		cn.getTextWindow().output(" |  |  /  _ \\__  \\   / __ | ");
		cn.getTextWindow().setCursorPosition(130, 29);
		cn.getTextWindow().output(" |  |_(  <_> ) __ \\_/ /_/ | ");
		cn.getTextWindow().setCursorPosition(130, 30);
		cn.getTextWindow().output(" |____/\\____(____  /\\____ | ");
		cn.getTextWindow().setCursorPosition(130, 31);
		cn.getTextWindow().output("                 \\/      \\/    ");

		cn.getTextWindow().setCursorPosition(130, 34);
		cn.getTextWindow().output("    _____                 ");
		cn.getTextWindow().setCursorPosition(130, 35);
		cn.getTextWindow().output("   /     \\ _____  ______  ");
		cn.getTextWindow().setCursorPosition(130, 36);
		cn.getTextWindow().output("  /  \\ /  \\\\__  \\ \\____ \\ ");
		cn.getTextWindow().setCursorPosition(130, 37);
		cn.getTextWindow().output(" /    Y    \\/ __ \\|  |_> >");
		cn.getTextWindow().setCursorPosition(130, 38);
		cn.getTextWindow().output(" \\____|__  (____  /   __/ ");
		cn.getTextWindow().setCursorPosition(130, 39);
		cn.getTextWindow().output("         \\/     \\/|__|    ");

		cn.getTextWindow().setCursorPosition(130, 42);
		cn.getTextWindow().output("________          __  .__                      ");
		cn.getTextWindow().setCursorPosition(130, 43);
		cn.getTextWindow().output("\\_____  \\ _______/  |_|__| ____   ____   ______");
		cn.getTextWindow().setCursorPosition(130, 44);
		cn.getTextWindow().output(" /   |   \\\\____ \\   __\\  |/  _ \\ /    \\ /  ___/");
		cn.getTextWindow().setCursorPosition(130, 45);
		cn.getTextWindow().output("/    |    \\  |_> >  | |  (  <_> )   |  \\\\___ \\ ");
		cn.getTextWindow().setCursorPosition(130, 46);
		cn.getTextWindow().output("\\_______  /   __/|__| |__|\\____/|___|  /____  >");
		cn.getTextWindow().setCursorPosition(130, 47);
		cn.getTextWindow().output("        \\/|__|                       \\/     \\/ ");

		cn.getTextWindow().setCursorPosition(130, 50);
		cn.getTextWindow().output("___________      .__  __   ");
		cn.getTextWindow().setCursorPosition(130, 51);
		cn.getTextWindow().output("\\_   _____/__  __|__|/  |_ ");
		cn.getTextWindow().setCursorPosition(130, 52);
		cn.getTextWindow().output(" |    __)_\\  \\/  /  \\   __\\");
		cn.getTextWindow().setCursorPosition(130, 53);
		cn.getTextWindow().output(" |        \\>    <|  ||  |  ");
		cn.getTextWindow().setCursorPosition(130, 54);
		cn.getTextWindow().output("/_______  /__/\\_ \\__||__|  ");
		cn.getTextWindow().setCursorPosition(130, 55);
		cn.getTextWindow().output("        \\/      \\/         ");

		int blood = 53;
		while (flag = true) {
			cn.getTextWindow().setCursorPosition(62, blood);
			cn.getTextWindow().output("0");
			blood++;
			Thread.sleep(1000);
			cn.getTextWindow().setCursorPosition(62, blood - 1);
			cn.getTextWindow().output(" ");
			if (blood == 58) {
				blood = 53;
			}
			cn.getTextWindow().addTextMouseListener(tmlis);
			if (flag==false){
				break;
			}

		}
		if (flag == false) {
			Game();
		}
	}
}
