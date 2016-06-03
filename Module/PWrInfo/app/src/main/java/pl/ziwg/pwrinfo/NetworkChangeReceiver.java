package pl.ziwg.pwrinfo;

/**
 * Created by Krystian on 01.06.2016.
 */

        import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.util.Log;
import android.view.View;
import android.widget.TextView;


public class NetworkChangeReceiver extends BroadcastReceiver {

    //Button button;
    TextView textView;

   // public NetworkChangeReceiver(Button button,TextView textView){
     //   this.button=button;
       // this.textView=textView;
//
  //  }
    public NetworkChangeReceiver(TextView textView){
        this.textView=textView;

    }

    boolean NetworkConnection = false;


    @Override
    public void onReceive(Context context, Intent intent) {
        NetworkConnection=haveNetworkConnection(context);
        Log.v("Status: ",Boolean.toString(NetworkConnection));

        if(!NetworkConnection) {
           // button.setVisibility(View.GONE);
            textView.setVisibility(View.VISIBLE);
        }else{
           // button.setVisibility(View.VISIBLE);
            textView.setVisibility(View.GONE);
        }



    }


    private boolean haveNetworkConnection(Context context) {

        boolean haveConnectedWifi = false;
        boolean haveConnectedMobile = false;

        ConnectivityManager cm = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo[] netInfo = cm.getAllNetworkInfo();
        for (NetworkInfo ni : netInfo) {
            if (ni.getTypeName().equalsIgnoreCase("WIFI"))
                if (ni.isConnected())
                    haveConnectedWifi = true;
            if (ni.getTypeName().equalsIgnoreCase("MOBILE"))
                if (ni.isConnected())
                    haveConnectedMobile = true;
        }
        return (haveConnectedWifi || haveConnectedMobile);
    }



}

