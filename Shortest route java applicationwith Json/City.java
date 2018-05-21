/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package tsp;

/**
 *
 * @author virkkalk
 */
public class City {

    private static final double EARTH_EQUATORIAL_RADIUS = 6378.1370D;
    static final double CONVERT_DEGREES_TO_RADIANS = Math.PI / 180D;

    public String city;
    public Double latitude;
    public Double longitude;
    public String cityname;
    public double path;
    
    //constructor av city
    public City(String city, double latitude, double longitude) {
        this.city = city;
        this.latitude = latitude * CONVERT_DEGREES_TO_RADIANS;
        this.longitude = longitude * CONVERT_DEGREES_TO_RADIANS;
        //return this.city + this.latitude + this.longitude;

    }

    @Override
    public String toString() {
        return this.getCity() + ": "
                + this.getLat() + ","
                + this.getLon();
    }

    public String getCity() {
        return city;
    }

    public Double getLat() {
        return latitude;
    }

    public Double getLon() {
        return longitude;
    }
    
    //räkning av distansen mellan städer med hjälp av Haversine formula
    public double getDistance(City city) {

        double deltaLongitude = city.getLon() - this.getLon();
        double deltaLatitude = city.getLat() - this.getLat();
        double a = Math.pow(Math.sin(deltaLatitude / 2D), 2D)
                + Math.cos(this.getLat()) * Math.cos(city.getLat()) * Math.pow(Math.sin(deltaLongitude / 2D), 2D);
        return EARTH_EQUATORIAL_RADIUS * 2D * Math.atan2(Math.sqrt(a), Math.sqrt(1D - a));

    }

}
