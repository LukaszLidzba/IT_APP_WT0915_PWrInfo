package pl.ziwg.pwrinfo;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;

// Activity was made to service menu for all activities

public class OwnActivity extends AppCompatActivity {

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        /*if(id == R.id.action_menu) {
            Intent getMenuScreenIntent = new Intent(this, MainActivity.class);
            startActivity(getMenuScreenIntent);
            return true;
        }
        else*/ if (id == R.id.action_messages) {
            Intent getMessageScreenIntent = new Intent(this, MessageActivity.class);
            startActivity(getMessageScreenIntent);
            return true;
        } else if (id == R.id.action_events) {
            Intent getEventScreenIntent = new Intent(this, EventActivity.class);
            startActivity(getEventScreenIntent);
            return true;
        } else if (id == R.id.action_deansOffice) {
            Intent getDeansOfficeScreenIntent = new Intent(this, DeansOfficeActivity.class);
            startActivity(getDeansOfficeScreenIntent);
            return true;
        } else if (id == R.id.action_libraries) {
            Intent getLibraryScreenIntent = new Intent(this, LibraryActivity.class);
            startActivity(getLibraryScreenIntent);
            return true;
        } /*else if (id == R.id.action_settings){
            return true;
        }*/ else if (id == R.id.action_map) {
            Intent getMapScreenIntent = new Intent(this, MapActivity.class);
            startActivity(getMapScreenIntent);
            return true;
        } else if (id == R.id.action_guide) {
                Intent getGuideScreenIntent = new Intent(this, GuideActivity.class);
                startActivity(getGuideScreenIntent);
                return true;
        } else if (id == R.id.action_info) {
            Intent getInfoScreenIntent = new Intent(this, InfoActivity.class);
            startActivity(getInfoScreenIntent);
            return true;
        } /*else if (id == R.id.exit_the_app) {
            finish();
            return true;
        }*/

        return super.onOptionsItemSelected(item);
    }
}
