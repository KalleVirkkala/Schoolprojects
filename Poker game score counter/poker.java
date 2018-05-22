

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Arrays;
import java.util.Scanner;

public class poker {

	private static Scanner sc;
	private Scanner myScan;
	Player player[];
	int intInputValue = 0; 
	void displayGameMenu() {// meny
		System.out.println();
		System.out.println("(1) Nytt spel");
		System.out.println("(5) Avsluta spel");
		System.out.print("V?lj ett alternativ: ");
	}

	void selectGameOption(int optionSelected) { // alternativ f?r meny
		switch (optionSelected) {
		case 1:
			this.startNewGame();
			break;
		default:
			break;
		}
	}

	void startNewGame() { //Startar nytt spel

		int r = 1;
		myScan = new Scanner(System.in);

		System.out.println("Hur m?nga spelare spelar? "); //ber anv?ndaren om  hur m?nga spelare
		int pSize = myScan.nextInt();
		Player player[] = new Player[pSize]; 
		for (int i = 0; i < pSize; i++) { // l?gger till spelare
			System.out.print("Ange namn: ");
			String pname = myScan.next();
			System.out.print("Ange klubb: ");
			String klubb = myScan.next();
			System.out.print("Ange insats: ");
			int insats = myScan.nextInt();
			player[i] = new Player(pname, klubb, insats);

		}
		int add = 0;

		int n = 0;

		for (int i = 0; i < player.length; i++) { // kontrolerar spelm?rkens summa
			n = player[i].getInsats();
			add += n;

		}

		while (r < 21) { // k?r genom 20 rundor
			
			//int n2 = 0;f?rs?k till att f?  kontroll p? att slut summan ?r 0
			//int add2 = 0;f?rs?k till att f?  kontroll p? att slut summan ?r 0
			
		

			for (int i = 0; i < player.length; i++) {// ger spel reslutat/ mellan rapport mellan varje runda 
				System.out.print("Spelare " + player[i].getPname() + ", " + player[i].getKlubb() + " spel resultat: "
						+ player[i].getInsats() + '\n');
			}

			System.out.print("Runda " + r + " spelat: ");

			for (int i = 0; i < player.length; i++) { // loopar genom spelarna och till?ter anv?ndaren att ?ndra v?rden p? spelm?rken
				System.out.print(
						"Ange spelare " + player[i].getPname() + ", " + player[i].getKlubb() + " spel resultat: ");
				player[i].setInsats(myScan.nextInt());
			//	n = player[i].getInsats();f?rs?k till att f?  kontroll p? att slut summan ?r 0
			//	add2 += n2; f?rs?k till att f?  kontroll p? att slut summan ?r 0
			}
			
			BufferedWriter writer = null;
			try {
				writer = new BufferedWriter(new FileWriter("player.txt")); // f?rstog hur jag skriver ner resultatet i en fil och sparar den lokalt men kom inte p? n?gon bra l?sning till att l?sa filen
			} catch (IOException e) {
				
				e.printStackTrace();
			}
				
				try {
					writer.write(Arrays.toString(player));
				} catch (IOException e) {
				
					e.printStackTrace();
				}
				try {
					writer.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			    
			
			System.out.println(Arrays.toString(player));
			r++;
		}
	}

	public static void main(String[] args) {
		System.out.println("Welcome to poker game");

		poker game = new poker();

		int optionSelected;

		while (true) {
			game.displayGameMenu(); // meny f?r spelet
			System.out.println();
			sc = new Scanner(System.in);
			optionSelected = sc.nextInt();

			while (optionSelected > 5 || optionSelected < 0) {

				System.out.print("Option entered invalid, please enter a number from 1 to 5: ");
				optionSelected = sc.nextInt();
			}

			if (optionSelected == 5) {
				System.out.println("Exiting game");
				break;
			}

			game.selectGameOption(optionSelected);

		}
	}
}
