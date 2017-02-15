import java.util.*;
import java.util.concurrent.ThreadLocalRandom;
import java.text.DecimalFormat;
public class Carer {
	private String name;
	private int Carer_Number;
	private int Carer_Turn;
	private int Carer_Turn2;
	private int Carer_Child;
	private String Carer_Job="n";
	private double Carer_amount;
	private boolean carerchecker=false;
	private double Carer_foodRate;
	private double Carer_toyRate;
	private double Carer_sleepRate;
	private double Carer_hygieneRate;
	private DecimalFormat df=new DecimalFormat("#.##");
	private int turn_jobdone=0;
	private double temp;//EDIT bu degisken eklendi
	public Carer(int carernumber){
		int minf=6;
		int maxf=18;
		int mint=3;
		int maxt=9;
		int mins=5;
		int maxs=15;
		int minh=8;
		int maxh=24;
		
		this.Carer_Number=carernumber;
		Carer_foodRate=ThreadLocalRandom.current().nextDouble(minf,maxf);
		Carer_toyRate=ThreadLocalRandom.current().nextDouble(mint,maxt);
		Carer_sleepRate=ThreadLocalRandom.current().nextDouble(mins,maxs);
		Carer_hygieneRate=ThreadLocalRandom.current().nextDouble(minh,maxh);
	}
	
	public  void Job(Child[] ch){//Carer is boolean
		boolean flag=true;
		
		if(Carer_Job.equalsIgnoreCase("f")){//food
			
			turn_jobdone=(int)(Carer_amount/Carer_foodRate)+1;
			while(flag==true){	
				
				if(Carer_amount>25){
					AmountChecker();
					turn_jobdone=0;
				}
				else{
					if(turn_jobdone>1){
					ch[Carer_Child].setFood(ch[Carer_Child].getFood()+Carer_foodRate);
					Carer_amount=Carer_amount-Carer_foodRate;
					}
					else if(turn_jobdone==1){
					ch[Carer_Child].setFood(ch[Carer_Child].getFood()+Carer_amount);	
					Carer_amount=0;	
					Carer_Job="n";
					}
						
					turn_jobdone--;
					break;
					}
				}
		}
		
		else if(Carer_Job.equalsIgnoreCase("g")){//game
			turn_jobdone=(int)(Carer_amount/Carer_toyRate)+1;
				while(flag==true){	
					
					if(Carer_amount>25){
						AmountChecker();
						turn_jobdone=0;
					}
					else{
						if(turn_jobdone>1){
							ch[Carer_Child].setToyGame(ch[Carer_Child].getToyGame()+Carer_toyRate);
							Carer_amount=Carer_amount-Carer_toyRate;
							}
							else if(turn_jobdone==1){
							ch[Carer_Child].setToyGame(ch[Carer_Child].getFood()+Carer_amount);	
							Carer_amount=0;	
							Carer_Job="n";
							}
								
							turn_jobdone--;
						break;
						}
					}
			}
		
		else if(Carer_Job.equalsIgnoreCase("s")){//sleep
			turn_jobdone=(int)(Carer_amount/Carer_hygieneRate)+1;
			Carer_Turn=(int)Carer_amount;
			if(Carer_amount==0){	
				
					ch[Carer_Child].setSleep(ch[Carer_Child].getSleep()+Carer_sleepRate);
					
			}
			else if(Carer_Turn>0){
				
				ch[Carer_Child].setSleep(ch[Carer_Child].getSleep()+Carer_sleepRate);
				Carer_Turn--;
				if(Carer_Turn==0){Carer_Job="n";}
			}
		}
			
		
		else if(Carer_Job.equalsIgnoreCase("h")){//hygiene
			turn_jobdone=(int)(Carer_amount/Carer_hygieneRate)+1;
			while(flag==true){	
				
				if(Carer_amount>25){
					AmountChecker();
					turn_jobdone=0;
				}
				else{
					if(turn_jobdone>1){
						ch[Carer_Child].setHygiene(ch[Carer_Child].getHygiene()+Carer_hygieneRate);
						Carer_amount=Carer_amount-Carer_hygieneRate;
						
						}
						else if(turn_jobdone==1){
						ch[Carer_Child].setHygiene(ch[Carer_Child].getHygiene()+Carer_amount);	
						Carer_amount=0;
						Carer_Job="n";
						}
							
						turn_jobdone--;
					break;
					}
				}
		}
		else if(Carer_Job.equalsIgnoreCase("c")){
			check();
		}
		else if(Carer_Job.equalsIgnoreCase("r")){
			terminate();
		}
	}

	public void AmountChecker(){
		
		System.out.println("You can't give more than 25 unit");
		
	}
	public void displayCarerInfos(){
		System.out.println("F:" +df.format(Carer_foodRate)+" G:" +df.format(Carer_toyRate)+" S:"+df.format(Carer_sleepRate)
			+" H:" +df.format(Carer_hygieneRate));
		
	}
	public void terminate(){
		Carer_Turn=ScreenTest.turn;
		
	}
	public void check(){

		Carer_Turn=ScreenTest.turn;
		carerchecker=true;//eger true ise ekranda cocuk degerleri yazdırılabilinir
	
		}
		
	
	public double getCarer_foodRate() {
		return Carer_foodRate;
	}
	public void setCarer_foodRate(double carer_foodRate) {
		Carer_foodRate = carer_foodRate;
	}
	public double getCarer_toyRate() {
		return Carer_toyRate;
	}
	public void setCarer_toyRate(double carer_toyRate) {
		Carer_toyRate = carer_toyRate;
	}
	public double getCarer_sleepRate() {
		return Carer_sleepRate;
	}
	public void setCarer_sleepRate(double carer_sleepRate) {
		Carer_sleepRate = carer_sleepRate;
	}
	public double getCarer_hygieneRate() {
		return Carer_hygieneRate;
	}
	public void setCarer_hygieneRate(double carer_hygieneRate) {
		Carer_hygieneRate = carer_hygieneRate;
	}
	public int getCarer_Number() {
		return Carer_Number;
	}
	public void setCarer_Number(int carer_Number) {
		Carer_Number = carer_Number;
	}
	public int getCarer_Turn() {
		return Carer_Turn;
	}
	public void setCarer_Turn(int carer_Turn) {
		Carer_Turn = carer_Turn;
	}
	public int getCarer_Child() {
		return Carer_Child;
	}
	public void setCarer_Child(int carer_Child) {
		Carer_Child = carer_Child;
	}
	public String getCarer_Job() {
		return Carer_Job;
	}
	public void setCarer_Job(String carer_Job) {
		Carer_Job = carer_Job;
	}
	public double getCarer_amount(){
		return Carer_amount;
	}
	public void setCarer_amount(double Carer_amount){//EDIT temp aktarımı yazıldı
		temp=Carer_amount;
		this.Carer_amount=Carer_amount;
	}
	
	public boolean isCarerchecker() {
		return carerchecker;
	}
	public void setCarerchecker(boolean carerchecker) {
		this.carerchecker = carerchecker;
	}

	public double getTemp() {
		return temp;
	}

	public void setTemp(double temp) {
		this.temp = temp;
	}

	public int getCarer_Turn2() {
		return Carer_Turn2;
	}

	public void setCarer_Turn2(int carer_Turn2) {
		Carer_Turn2 = carer_Turn2;
	}
	
	
		
		
	}
	

