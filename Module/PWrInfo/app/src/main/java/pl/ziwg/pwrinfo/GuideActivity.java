package pl.ziwg.pwrinfo;

import android.app.TabActivity;
import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TabHost;

import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;


public class GuideActivity extends TabActivity{

    TabHost tabHost;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_guide);

        tabHost = (TabHost)findViewById(android.R.id.tabhost);

        TabHost.TabSpec ts1 = tabHost.newTabSpec("page 1");
        ts1.setIndicator("Kandydaci");
        ts1.setContent(new Intent(this, GuideActivityTab1.class));
        tabHost.addTab(ts1);

        TabHost.TabSpec ts2 = tabHost.newTabSpec("page 2");
        ts2.setIndicator("Studenci");
        ts2.setContent(new Intent(this, GuideActivityTab2.class));
        tabHost.addTab(ts2);

        TabHost.TabSpec ts3 = tabHost.newTabSpec("page 3");
        ts3.setIndicator("Absolwenci");
        ts3.setContent(new Intent(this, GuideActivityTab3.class));
        tabHost.addTab(ts3);

    }

}
