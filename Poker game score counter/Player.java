



public class Player  {
    String pname;
    String klubb;
    int insats;
    
public Player(String pname ,String klubb, int insats){
this.pname = pname;
this.klubb = klubb;
this.insats = insats;
}
public String toString() {
    return pname + "," + klubb + ","+ insats ;
}

public void setInsats(int insats){
this.insats += insats;
 
}
public String getKlubb(){
	 return klubb;
	 
	}
public int getInsats(){
	 return insats;
	 
	}

public String getPname(){
	 return pname;
	 
	}
}