package com.example.toursmobileapp;


import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListView;


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;



import androidx.appcompat.app.AppCompatActivity;


public class MainActivity extends AppCompatActivity {
    private HotelAdapter mAdapter;
    private List<Hotel> mHotelsList = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView lvHotels = findViewById(R.id.listViewHotels);
        mAdapter = new HotelAdapter(MainActivity.this, mHotelsList);
        lvHotels.setAdapter(mAdapter);

        new GetHotels().execute();
    }

    private class GetHotels extends AsyncTask<Void,Void, String> {
        @Override
        public String doInBackground(Void... voids) {
            try {

                URL url = new URL("http://10.0.2.2:19026/api/hotels");
                HttpURLConnection connection = (HttpURLConnection)url.openConnection();

                BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));


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
            super.onPostExecute(s);

            if (s != null) {
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
                    }
                    mAdapter.notifyDataSetChanged();
                } catch (JSONException e) {
                    // Обработка ошибки парсинга JSON
                    e.printStackTrace();
                    Log.e("JSON Parsing Error", "Error parsing JSON: " + s);
                }
            } else {
                // Обработка случая, когда результат равен null
                Log.e("JSON Parsing Error", "Result is null");
            }
        }

    }
}
