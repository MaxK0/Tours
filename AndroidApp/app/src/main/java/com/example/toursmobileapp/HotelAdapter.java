package com.example.toursmobileapp;

import android.content.Context;
import android.content.Intent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;

import java.util.List;

public class HotelAdapter extends BaseAdapter {
    private Context mContext;
    private List<Hotel> mHotelsList;

    public HotelAdapter(Context mContext, List<Hotel> mHotelsList) {
        this.mContext = mContext;
        this.mHotelsList = mHotelsList;
    }

    @Override
    public int getCount() {
        return mHotelsList.size();
    }

    @Override
    public Object getItem(int i) {
        return mHotelsList.get(i);
    }

    @Override
    public long getItemId(int i) {
        return mHotelsList.get(i).getId();
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View v = View.inflate(mContext, R.layout.item_hotel, null);

        ImageView imgSource = v.findViewById(R.id.imageViewItemHotelPhoto);
        TextView txtName = v.findViewById(R.id.textViewItemHotelName);
        final RatingBar rtStars = v.findViewById(R.id.ratingBarItemHotelStars);

        final Hotel currentHotel = mHotelsList.get(i);

        imgSource.setImageBitmap(currentHotel.getBitmapSource());
        txtName.setText(currentHotel.getName());
        rtStars.setRating(currentHotel.getCountOfStars());

        v.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intentDetails = new Intent(mContext, DetailsActivity.class);

                intentDetails.putExtra("hotel", currentHotel);

                mContext.startActivity(intentDetails);
            }
        });

        return v;
    }
}
