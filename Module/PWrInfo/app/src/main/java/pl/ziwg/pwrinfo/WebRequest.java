package pl.ziwg.pwrinfo;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;

public class WebRequest {

    /**
     * Making web service call
     *
     * @url - url to make web request
     * @params - idWydzialu if needed
     */
    public String makeWebServiceCall(String urlAddress,
                                     String params) {
        URL url;
        String correctUrlAddress = urlAddress;
        String response = "";

        if (params != null) {
            correctUrlAddress = correctUrlAddress + "/" + params;
        }

        try {
            url = new URL(correctUrlAddress);
            HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
            httpURLConnection.setRequestMethod("GET");

            int reqresponseCode = httpURLConnection.getResponseCode();

            if (reqresponseCode == HttpsURLConnection.HTTP_OK) {
                String line;
                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(httpURLConnection.getInputStream()));
                while ((line = bufferedReader.readLine()) != null) {
                    response += line;
                }
            } else {
                response = "";
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        return response;
    }
}
