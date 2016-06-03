package pl.ziwg.pwrinfo;

import android.content.IntentFilter;
import android.net.ConnectivityManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import org.json.JSONException;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class LibraryActivity extends OwnActivity {

    final static private String urlLibrary = "http://zedd.azurewebsites.net/RestDataService.svc/libraries";
    final static private String TAG_NAME = "name";
    final static private String TAG_ADDRESS = "address";
    final static private String TAG_OPENING_HOURS = "openingHours";
    final static private String TAG_ADDITIONAL_INFO = "additionalInfo";

    public NetworkChangeReceiver networkChangeReceiver;
    public TextView internetconnectionTextViewLibrary;
    public IntentFilter filter;
    public LibraryActivity() {
        filter = new IntentFilter(ConnectivityManager.CONNECTIVITY_ACTION);
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.library_activity);
        new RetrieveLibrary().execute(urlLibrary);

        internetconnectionTextViewLibrary = (TextView) findViewById(R.id.BrakInternetuLibrary);

        networkChangeReceiver = new NetworkChangeReceiver(internetconnectionTextViewLibrary);
        registerReceiver(networkChangeReceiver, filter);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    private class RetrieveLibrary extends AsyncTask<String, Void, Void> {
        List<Map<String, String>> data;
        ListView listView = (ListView) findViewById(R.id.listView_library);

        @Override
        protected Void doInBackground(String... params) {
            data = new ArrayList<Map<String, String>>();
            WebRequest webRequest = new WebRequest();
            String download = webRequest.makeWebServiceCall(params[0], null);
            JsonParser jsonParser = new JsonParser();

            try {
                jsonParser.LibrariesJson(download, data);
            } catch (JSONException e) {
                e.printStackTrace();
            }

            return null;
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            super.onPostExecute(aVoid);
            SimpleAdapter adapter = new SimpleAdapter(LibraryActivity.this, data,
                    R.layout.library_list,
                    new String[]{TAG_NAME, TAG_ADDRESS, TAG_OPENING_HOURS, TAG_ADDITIONAL_INFO},
                    new int[]{R.id.library_name,
                            R.id.library_address, R.id.library_openingHours, R.id.library_additionalInfo});
            listView.setAdapter(adapter);
        }
    }
}


