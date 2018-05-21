/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tsp;

/**
 *
 * @author kalle
 */
public class result {
    private final String cityname;
    private final double path;
    //lättare constructor för reultat visning
    public result(String cityname, double path)
    {
        this.cityname = cityname;
        this.path = path;
      
     
    }  
    
     @Override
     
public String toString() {
    return this.getCityname() +": "+ 
           this.getPath();
} 
    public String getCityname()
    {
        return cityname;
    }
    public Double getPath()
    {
        return path;
    }

   
    
    

}
