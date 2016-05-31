package pl.ziwg.pwrinfo;

import android.os.Bundle;
import android.widget.TextView;

public class NotificationActivity extends OwnActivity {

    final static private String TAG_TITLE = "title";
    final static private String TAG_DATE = "date";
    final static private String TAG_DATA = "data";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.notification_activity);

        String title, content, date;

        if (savedInstanceState == null) {
            Bundle extras = getIntent().getExtras();
            if(extras == null) {
                title = null;
                date = null;
                content = null;
            } else {
                title = extras.getString(TAG_TITLE);
                date = extras.getString(TAG_DATE);
                content = extras.getString(TAG_DATA);
            }
        } else {
            title = (String) savedInstanceState.getSerializable(TAG_TITLE);
            date = (String) savedInstanceState.getSerializable(TAG_DATE);
            content = (String) savedInstanceState.getSerializable(TAG_DATA);
        }

        TextView textViewTitle = (TextView) findViewById(R.id.notification_title);
        TextView textViewDate = (TextView) findViewById(R.id.notification_date);
        TextView textViewContent = (TextView) findViewById(R.id.notification_content);

        textViewTitle.setText(title);
        textViewDate.setText(date);
        textViewContent.setText(content);
    }


}
