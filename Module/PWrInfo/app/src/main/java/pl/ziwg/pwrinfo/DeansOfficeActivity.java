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

public class DeansOfficeActivity extends OwnActivity implements AdapterView.OnItemSelectedListener {
    final static private String urlDeansOffice = "http://zedd.azurewebsites.net/RestDataService.svc/deansOffice";
    final static private String TAG_ADDRESS = "address";
    final static private String TAG_OPENING_HOURS = "openingHours";
    final static private String TAG_ADDITIONAL_INFO = "additionalInfo";

    public NetworkChangeReceiver networkChangeReceiver;
    public TextView internetconnectionTextViewDeansOffice;
    public IntentFilter filter;
    public DeansOfficeActivity() {
        filter = new IntentFilter(ConnectivityManager.CONNECTIVITY_ACTION);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.deansoffice_activity);
        Spinner spinner = (Spinner) findViewById(R.id.spinner_deansOffice);
        spinner.setOnItemSelectedListener(this);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
                R.array.list_of_departments, android.R.layout.simple_spinner_item);

        // Specify the layout to use when the list of choices appears
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        // Apply the adapter to the spinner
        spinner.setAdapter(adapter);

        internetconnectionTextViewDeansOffice = (TextView) findViewById(R.id.BrakInternetuDeansOffice);

        networkChangeReceiver = new NetworkChangeReceiver(internetconnectionTextViewDeansOffice);
        registerReceiver(networkChangeReceiver, filter);

    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        Toast.makeText(this, "Wczytywanie danych", Toast.LENGTH_SHORT).show();
        new RetrieveDeansOffice().execute(urlDeansOffice, Integer.toString(position + 1));
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    private class RetrieveDeansOffice extends AsyncTask<String, Void, Void> {
        List<Map<String, String>> data;
        ListView listView = (ListView) findViewById(R.id.listView_deansOffice);

        @Override
        protected Void doInBackground(String... params) {
            data = new ArrayList<Map<String,String>>();
            WebRequest webRequest = new WebRequest();
            String download = webRequest.makeWebServiceCall(params[0], params[1]);
            JsonParser jsonParser = new JsonParser();
            try {
                jsonParser.DeansOfficeJson(download, data);
            } catch (JSONException e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            super.onPostExecute(aVoid);
            SimpleAdapter adapter = new SimpleAdapter(DeansOfficeActivity.this, data,
                    R.layout.deansoffice_list,
                    new String[]{TAG_ADDRESS, TAG_OPENING_HOURS, TAG_ADDITIONAL_INFO},
                    new int[]{R.id.deansOffice_address,
                            R.id.deansOffice_openingHours, R.id.deansOffice_additionalInfo});
            listView.setAdapter(adapter);
        }
    }
}
