package pl.ziwg.pwrinfo;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;


/**
 * A simple {@link Fragment} subclass.
 */
public class TabFragment3 extends Fragment {


    public TabFragment3() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.tab_fragment_3, container, false);

        // String htmlAsString = getString(R.string.kandydaci);
        WebView webView = (WebView)rootView.findViewById(R.id.webView);
        webView.clearCache(true);

        webView.getSettings().setJavaScriptEnabled(true);
        webView.loadUrl("http://krystiankaliciak.tk/absolwent.html");
        //webView.loadDataWithBaseURL(null, htmlAsString, "text/html", "utf-8", null);

        // Inflate the layout for this fragment
        return rootView;
    }


}