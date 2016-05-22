package pl.ziwg.pwrinfo;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends OwnActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button button_message =  (Button) findViewById(R.id.button_message);
        button_message.setOnClickListener(this);

        Button button_event =  (Button) findViewById(R.id.button_event);
        button_event.setOnClickListener(this);

        Button button_library =  (Button) findViewById(R.id.button_library);
        button_library.setOnClickListener(this);

        Button button_deansOffice =  (Button) findViewById(R.id.button_deansOffice);
        button_deansOffice.setOnClickListener(this);

        Button button_map_ =  (Button) findViewById(R.id.button_map);
        button_map_.setOnClickListener(this);

        Button button_info =  (Button) findViewById(R.id.button_info);
        button_info.setOnClickListener(this);

    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.button_message:
                Intent getMessageScreenIntent = new Intent(this, MessageActivity.class);
                startActivity(getMessageScreenIntent);
                break;
            case R.id.button_event:
                Intent getEventScreenIntent = new Intent(this, EventActivity.class);
                startActivity(getEventScreenIntent);
                break;
            case R.id.button_library:
                Intent getLibraryScreenIntent = new Intent(this, LibraryActivity.class);
                startActivity(getLibraryScreenIntent);
                break;
            case R.id.button_deansOffice:
                Intent getDeansOfficeScreenIntent = new Intent(this, DeansOfficeActivity.class);
                startActivity(getDeansOfficeScreenIntent);
                break;
            case R.id.button_map:
                Intent getMapScreenIntent = new Intent(this, MapActivity.class);
                startActivity(getMapScreenIntent);
                break;
            case R.id.button_info:
                Intent getInfoScreenIntent = new Intent(this, InfoActivity.class);
                startActivity(getInfoScreenIntent);
                break;
            default:
                break;
        }
    }
}
