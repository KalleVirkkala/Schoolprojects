/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tsp;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;

/**
 *
 * @author virkkalk
 */
public class main {

    public static ArrayList<City> waypoints = new ArrayList();


    public static void main(String[] args) throws FileNotFoundException, ParseException, IOException {
        FileReader fr = new FileReader("waypoints.json");
        JSONParser jp = new JSONParser();
        JSONObject jo = (JSONObject) jp.parse(fr);
        JSONArray ja = (JSONArray) jo.get("waypoints");

        HashMap<String, City> cities = new HashMap();

        //hämtar infon från json filen lägger dom i en constructor av City och i en arraylist waypoints
        for (Object ja1 : ja) {
            JSONObject jsonElement = (JSONObject) ja1;
            String city = jsonElement.get("city").toString();
            String latitude = jsonElement.get("latitude").toString();
            double lat = Double.parseDouble(latitude);
            String longitude = jsonElement.get("longitude").toString();
            double lon = Double.parseDouble(longitude);
            City town = new City(city, lat, lon);
            cities.put(city, town);
            waypoints.add(town);
        }

      
        //indexen för alla 10 städer
        int[] indexes = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        //permutering
        Permute.permute(indexes, 1, indexes.length);

        System.out.print("\n");
        
        if (Permute.CalculatedRoute.isEmpty()) {
            return;
        }
        //kontroll efter den minsta distancen i arraylist CalculatedRoute 
        double small1 = Permute.CalculatedRoute.get(0).getPath();
        
        System.out.print("Calclulating Route ------->");
        System.out.print("\n");
        
        for (result CalculatedRoute : Permute.CalculatedRoute) {
            if (CalculatedRoute.getPath() < small1) {
                small1 = CalculatedRoute.getPath();
            }
        }
        
        for (result CalculatedRoute : Permute.CalculatedRoute) {
            if (CalculatedRoute.getPath().equals(small1)) {
                System.out.print(CalculatedRoute.getCityname() + "    ==>At a total length of " + Math.round(small1) + " km");
                System.out.print("\n");
            }
        }

    }

}
