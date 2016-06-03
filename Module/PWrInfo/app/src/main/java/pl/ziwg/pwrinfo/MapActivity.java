package pl.ziwg.pwrinfo;

import android.os.Bundle;

public class MapActivity extends OwnActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.map_activity);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }
}
