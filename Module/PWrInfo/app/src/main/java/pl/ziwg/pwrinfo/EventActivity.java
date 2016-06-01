package pl.ziwg.pwrinfo;

import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import android.widget.TextView;
import android.content.Intent;
import android.content.IntentFilter;
import android.net.ConnectivityManager;

import org.json.JSONException;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class EventActivity extends OwnActivity implements AdapterView.OnItemSelectedListener {

    final static private String urlEvent = "http://zedd.azurewebsites.net/RestDataService.svc/events";
    final static private String TAG_TITLE = "title";
    final static private String TAG_DATE = "date";
    final static private String TAG_DATA = "data";

    public NetworkChangeReceiver networkChangeReceiver;
    public TextView internetconnectionTextViewEvent;
    public IntentFilter filter;
    public EventActivity() {
        filter = new IntentFilter(ConnectivityManager.CONNECTIVITY_ACTION);
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.event_activity);

        Spinner spinner = (Spinner) findViewById(R.id.spinner_event);
        spinner.setOnItemSelectedListener(this);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
                R.array.list_of_departments, android.R.layout.simple_spinner_item);

        // Specify the layout to use when the list of choices appears
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        // Apply the adapter to the spinner
        spinner.setAdapter(adapter);


        internetconnectionTextViewEvent = (TextView) findViewById(R.id.BrakInternetuEvent);

        networkChangeReceiver = new NetworkChangeReceiver(internetconnectionTextViewEvent);
        registerReceiver(networkChangeReceiver, filter);
    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        Toast.makeText(this, "Wczytywanie danych", Toast.LENGTH_SHORT).show();
        new RetrieveEvent().execute(urlEvent, Integer.toString(position + 1));
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    private class RetrieveEvent extends AsyncTask<String, Void, Void> {
        List<Map<String, String>> data;
        ListView listView = (ListView) findViewById(R.id.listView_event);

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
            SimpleAdapter adapter = new SimpleAdapter(EventActivity.this, data,
                    R.layout.event_list,
                    new String[]{TAG_TITLE, TAG_DATE, TAG_DATA},
                    new int[]{R.id.event_title,
                            R.id.event_date, R.id.event_content});
            listView.setAdapter(adapter);

        }
    }
}
