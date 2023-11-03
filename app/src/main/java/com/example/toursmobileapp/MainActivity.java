package com.example.toursmobileapp;


import android.os.Bundle;
import android.widget.ListView;

import androidx.appcompat.app.AppCompatActivity;

import org.chromium.base.task.AsyncTask;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;


public class MainActivity extends AppCompatActivity {
    private HotelAdapter mAdapter;
    private List<Hotel> mHotelsList = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView lvHotels = findViewById(R.id.listViewHotel);
        mAdapter = new HotelAdapter(MainActivity.this, mHotelsList);
        lvHotels.setAdapter(mAdapter);

        new GetHotels(); //new GetHotels.execute();
    }

    private class GetHotels extends AsyncTask<String> implements com.example.toursmobileapp.GetHotels {
        @Override
        public String doInBackground(Void... voids) {
            try {
                URL url = new URL("https://10.0.2.2:63450/api/hotels");
                HttpURLConnection connection = (HttpURLConnection)url.openConnection();

                BufferedReader reader = new BufferedReader(new InputStreamReader((connection.getInputStream())));

                StringBuilder result = new StringBuilder();
                String line = "";

                while ((line = reader.readLine()) != null) {
                    result.append(line);
                }

                return result.toString();
            }
            catch (Exception ex) {
                return null;
            }
        }

        @Override
        protected void onPostExecute(String s) {
            //super.onPostExecute(s);
            try {
                JSONArray tempArray = new JSONArray(s);
                for (int i = 0; i < tempArray.length(); i++) {
                    JSONObject hotelJson = tempArray.getJSONObject(i);
                    Hotel tempHotel = new Hotel(

                            hotelJson.getInt("Id"),
                            hotelJson.getString("Name"),
                            hotelJson.getInt("CountOfStars"),
                            hotelJson.getString("HotelImage")
                    );
                    mHotelsList.add(tempHotel);
                    mAdapter.notifyDataSetChanged();
                }
            } catch (JSONException e) {
                throw new RuntimeException(e);
            }
        }

        @Override
        protected String doInBackground() {
            return null;
        }

        @Override
        public void onPostExecute(Void unused) {

        }
    }
}
