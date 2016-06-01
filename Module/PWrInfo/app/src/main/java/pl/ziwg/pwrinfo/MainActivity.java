package pl.ziwg.pwrinfo;

import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.NotificationCompat;
import android.text.format.DateUtils;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.content.Intent;
import android.content.IntentFilter;
import android.net.ConnectivityManager;

import org.json.JSONException;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

public class MainActivity extends OwnActivity implements View.OnClickListener {

    final static private String urlEvent = "http://zedd.azurewebsites.net/RestDataService.svc/events";
    final static private String TAG_TITLE = "title";
    final static private String TAG_DATE = "date";
    final static private String TAG_DATA = "data";
    final static private String TAG_NOTIFICATION = "notificationDate";

    public NetworkChangeReceiver networkChangeReceiver;
    public TextView internetconnectionTextView;

    public IntentFilter filter;

    public MainActivity() {
        filter = new IntentFilter(ConnectivityManager.CONNECTIVITY_ACTION);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button button_message =  (Button) findViewById(R.id.button_message);
        button_message.setOnClickListener(this);

        Button button_event =  (Button) findViewById(R.id.button_event);
        button_event.setOnClickListener(this);

        Button button_library =  (Button) findViewById(R.id.button_library);
        button_library.setOnClickListener(this);

        Button button_deansOffice =  (Button) findViewById(R.id.button_deansOffice);
        button_deansOffice.setOnClickListener(this);

        Button button_map_ =  (Button) findViewById(R.id.button_map);
        button_map_.setOnClickListener(this);

        Button button_info =  (Button) findViewById(R.id.button_info);
        button_info.setOnClickListener(this);

        for (int i = 1; i <= 1; i++) {
            new RetrieveNotification().execute(urlEvent, Integer.toString(i));
        }

        internetconnectionTextView = (TextView) findViewById(R.id.BrakInternetu);

        networkChangeReceiver = new NetworkChangeReceiver(internetconnectionTextView);
        registerReceiver(networkChangeReceiver, filter);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.button_message:
                Intent getMessageScreenIntent = new Intent(this, MessageActivity.class);
                startActivity(getMessageScreenIntent);
                break;
            case R.id.button_event:
                Intent getEventScreenIntent = new Intent(this, EventActivity.class);
                startActivity(getEventScreenIntent);
                break;
            case R.id.button_library:
                Intent getLibraryScreenIntent = new Intent(this, LibraryActivity.class);
                startActivity(getLibraryScreenIntent);
                break;
            case R.id.button_deansOffice:
                Intent getDeansOfficeScreenIntent = new Intent(this, DeansOfficeActivity.class);
                startActivity(getDeansOfficeScreenIntent);
                break;
            case R.id.button_map:
                Intent getMapScreenIntent = new Intent(this, MapActivity.class);
                startActivity(getMapScreenIntent);
                break;
            case R.id.button_info:
                Intent getInfoScreenIntent = new Intent(this, InfoActivity.class);
                startActivity(getInfoScreenIntent);
                break;
            default:
                break;
        }
    }

    private void createNotification (String title, String content, String date, int id) {
        Bitmap bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.logo);
        NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
                .setSmallIcon(R.drawable.logodwa)
                .setLargeIcon(bitmap)
                .setContentTitle(title)
                .setContentText(content)
                .setAutoCancel(true);

        Intent intent = new Intent(this, NotificationActivity.class);

        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK |
                Intent.FLAG_ACTIVITY_CLEAR_TASK);

        intent.putExtra(TAG_TITLE, title);
        intent.putExtra(TAG_DATA, content);
        intent.putExtra(TAG_DATE, date);

        PendingIntent notifyIntent =
                PendingIntent.getActivity(
                        this,
                        id,
                        intent,
                        PendingIntent.FLAG_UPDATE_CURRENT
                );


        builder.setContentIntent(notifyIntent);

        NotificationManager mNotificationManager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);

        mNotificationManager.notify(id, builder.build());

    }

    private class RetrieveNotification extends AsyncTask<String, Void, Void> {
        List<Map<String, String>> data;

        @Override
        protected Void doInBackground(String... params) {
            data = new ArrayList<Map<String,String>>();
            WebRequest webRequest = new WebRequest();
            String download = webRequest.makeWebServiceCall(params[0], params[1]);
            JsonParser jsonParser = new JsonParser();
            try {
                jsonParser.EventsJson(download, data);
            } catch (JSONException e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            super.onPostExecute(aVoid);
            int id = 0;
            boolean wasNotification = false;

            if (!wasNotification) {
                wasNotification = true;
                for (int i = 0; i < data.size(); i++) {
                    Map<String, String> datum = data.get(i);
                    Date date = stringToDate(datum.get(TAG_NOTIFICATION));
                    //Date test = stringToDate("6/1/2016 00:00:00 AM");  //!!! Testowe

                    if (DateUtils.isToday(date.getTime()/*test.getTime()*/)) {
                        createNotification(datum.get(TAG_TITLE), datum.get(TAG_DATA), datum.get(TAG_DATE), ++id);
                    }
                }
            }
        }

        private Date stringToDate (String string) {
            // Format: "4/21/2016 12:00:00 AM"
            Date tempDate = null;
            SimpleDateFormat format = new SimpleDateFormat("MM/dd/yyyy' 'KK:mm:ss' 'aa");
            try {
                tempDate = format.parse(string);
            } catch (ParseException e) {
                e.printStackTrace();
            }
            return tempDate;
        }

    }
}
