package pl.ziwg.pwrinfo;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class JsonParser {

    final static private String TAG_TITLE = "title";
    final static private String TAG_NAME = "name";
    final static private String TAG_ADDRESS = "address";
    final static private String TAG_OPENING_HOURS = "openingHours";
    final static private String TAG_ADDITIONAL_INFO = "additionalInfo";
    final static private String TAG_DATA = "data";

    public void MessagesJson (String data, List<Map<String,String>> dataList) throws JSONException {
        JSONArray jsonArray = new JSONArray(data);

        for (int i = 0; i < jsonArray.length(); i++) {
            JSONObject jsonObject = jsonArray.getJSONObject(i);
            Map<String,String> datum = new HashMap<String, String>(2);
            datum.put(TAG_TITLE, jsonObject.getString("Title"));
            datum.put(TAG_DATA, jsonObject.getString("Content"));
            dataList.add(datum);
        }
    }
    
    public void EventsJson (String data, ArrayList<EventClass> arrayList) throws JSONException {
        JSONArray jsonArray = new JSONArray(data);

        for (int i = 0; i < jsonArray.length(); i++) {
            JSONObject jsonObject = jsonArray.getJSONObject(i);
            arrayList.add(new EventClass(jsonObject.getInt("Id"), jsonObject.getString("Title"),
                    jsonObject.getString("Content"), jsonArray.getInt(0),
                    jsonArray.getString(1), jsonObject.getString("Date"),
                    jsonObject.getString("NotificationDate")));
        }
    }

    public void LibrariesJson (String data, List<Map<String, String>> dataList) throws JSONException {
        JSONArray jsonArray = new JSONArray(data);

        for (int i = 0; i < jsonArray.length(); i++) {
            JSONObject jsonObject = jsonArray.getJSONObject(i);
            Map<String, String> datum = new HashMap<String, String>(2);
            datum.put(TAG_NAME, jsonObject.getString("Name"));
            datum.put(TAG_ADDRESS, jsonObject.getString("Address"));
            datum.put(TAG_OPENING_HOURS, jsonObject.getString("OpeningHours"));
            datum.put(TAG_ADDITIONAL_INFO, jsonObject.getString("AdditionalInfo"));
            System.out.print("JSON: " + datum.get(TAG_NAME));
            dataList.add(datum);
            /*dataList.add(new LibraryClass(jsonObject.getInt("Id"),
                    jsonObject.getString("Name"), jsonObject.getString("Address"),
                    jsonObject.getString("AdditionalInfo"), jsonObject.getString("OpeningHours")));*/

        }
    }

    public void DeansOfficeJson (String data, ArrayList<DeansOfficeClass> arrayList) throws JSONException {
        JSONArray jsonArray = new JSONArray(data);

        for (int i = 0; i < jsonArray.length(); i++) {
            JSONObject jsonObject = jsonArray.getJSONObject(i);
            arrayList.add(new DeansOfficeClass(jsonObject.getInt("Id"),
                    jsonArray.getString(1), jsonObject.getString("Address"),
                    jsonObject.getString("AdditionalInfo"), jsonObject.getString("OpeningHours")));
        }
    }
}
