package tsp;


import java.io.IOException;
import java.util.ArrayList;
import static tsp.main.waypoints;


/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author kalle
 */
public class Permute {

    public static ArrayList<result> CalculatedRoute = new ArrayList();


    public static void permute(int[] array, int i, int length) throws IOException {

        if (length == i) {
            //permutering av alla städers distance och namn
            //lägger alla resultat i en constructor av result och sedan lägger dom i en arraylist CalculatedRoute
            for (int k = 0; k < array.length; k++) {

            }

            double num = waypoints.get(array[0]).getDistance(waypoints.get(array[1]))
                    + waypoints.get(array[1]).getDistance(waypoints.get(array[2]))
                    + waypoints.get(array[2]).getDistance(waypoints.get(array[3]))
                    + waypoints.get(array[3]).getDistance(waypoints.get(array[4]))
                    + waypoints.get(array[4]).getDistance(waypoints.get(array[5]))
                    + waypoints.get(array[5]).getDistance(waypoints.get(array[6]))
                    + waypoints.get(array[6]).getDistance(waypoints.get(array[7]))
                    + waypoints.get(array[7]).getDistance(waypoints.get(array[8]))
                    + waypoints.get(array[8]).getDistance(waypoints.get(array[9]))
                    + waypoints.get(array[9]).getDistance(waypoints.get(array[0]));
            String name = waypoints.get(array[0]).getCity() + " | "
                    + waypoints.get(array[1]).getCity() + " | "
                    + waypoints.get(array[2]).getCity() + " | "
                    + waypoints.get(array[3]).getCity() + " | "
                    + waypoints.get(array[4]).getCity() + " | "
                    + waypoints.get(array[5]).getCity() + " | "
                    + waypoints.get(array[6]).getCity() + " | "
                    + waypoints.get(array[7]).getCity() + " | "
                    + waypoints.get(array[8]).getCity() + " | "
                    + waypoints.get(array[9]).getCity() + " | "
                    + waypoints.get(array[0]).getCity();
            result qwe = new result(name, num);
            CalculatedRoute.add(qwe);

            return;
        }
        int j = i;
        //permute operatorn
        for (j = i; j < length; j++) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            permute(array, i + 1, length);

            temp = array[i];

            array[i] = array[j];

            array[j] = temp;

        }

        return;

    }

}
