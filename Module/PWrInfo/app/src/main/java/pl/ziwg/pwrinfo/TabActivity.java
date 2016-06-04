package pl.ziwg.pwrinfo;

import android.content.IntentFilter;
import android.net.ConnectivityManager;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.widget.TextView;

public class TabActivity extends OwnActivity {
    ViewPager  pager;
    TabLayout tabLayout;

    public NetworkChangeReceiver networkChangeReceiver;
    public TextView internetConnectionTextViewDeansOffice;
    public IntentFilter filter;
    public TabActivity() {
        filter = new IntentFilter(ConnectivityManager.CONNECTIVITY_ACTION);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tab);

        pager= (ViewPager) findViewById(R.id.view_pager);
        tabLayout= (TabLayout) findViewById(R.id.tab_layout);

        FragmentManager manager=getSupportFragmentManager();
        PagerAdapter adapter=new PagerAdapter(manager);
        pager.setAdapter(adapter);

        tabLayout.setupWithViewPager(pager);
        // mTabLayout.setupWithViewPager(mPager1);
        pager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tabLayout));

        tabLayout.setTabsFromPagerAdapter(adapter);

        internetConnectionTextViewDeansOffice = (TextView) findViewById(R.id.BrakInternetuDeansOffice);

        networkChangeReceiver = new NetworkChangeReceiver(internetConnectionTextViewDeansOffice);
        registerReceiver(networkChangeReceiver, filter);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

    }

    @Override
    protected void onStop()
    {
        unregisterReceiver(networkChangeReceiver);
        super.onStop();
    }
}
