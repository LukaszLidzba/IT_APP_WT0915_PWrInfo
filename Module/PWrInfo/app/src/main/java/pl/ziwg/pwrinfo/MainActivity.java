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

import org.json.JSONException;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class MainActivity extends OwnActivity implements AdapterView.OnItemSelectedListener {

    final private static String urlMessages = "http://zedd.azurewebsites.net/RestDataService.svc/messages";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Spinner spinner = (Spinner) findViewById(R.id.spinner_main);
        spinner.setOnItemSelectedListener(this);
        // Create an ArrayAdapter using the string array and a default spinner layout
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
                R.array.list_of_departments, android.R.layout.simple_spinner_item);

        // Specify the layout to use when the list of choices appears
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        // Apply the adapter to the spinner
        spinner.setAdapter(adapter);
    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        Toast.makeText(this, "Wczytywanie danych", Toast.LENGTH_SHORT).show();
        new RetrieveMessage().execute(urlMessages, Integer.toString(position + 1));
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    private class RetrieveMessage extends AsyncTask<String, Void, Void> {
        List<Map<String, String>> data;
        ListView listView = (ListView) findViewById(R.id.listView_main);

        protected Void doInBackground(String... params) {
            data = new ArrayList<Map<String,String>>();
            WebRequest webRequest = new WebRequest();
            String download = webRequest.makeWebServiceCall(params[0], params[1]);
            JsonParser jsonParser = new JsonParser();
            try {
                jsonParser.MessagesJson(download, data);

            } catch (JSONException e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            super.onPostExecute(aVoid);
            SimpleAdapter adapter = new SimpleAdapter(MainActivity.this, data,
                    android.R.layout.simple_list_item_2, new String[]{"title", "data"},
                    new int[]{android.R.id.text1,
                            android.R.id.text2});
            listView.setAdapter(adapter);
        }
    }
}
