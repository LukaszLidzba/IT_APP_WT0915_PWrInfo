package pl.ziwg.pwrinfo;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class EventClass {
    private int id;
    private String title;
    private String content;
    private int idDeansOffice;
    private String deansOfficeName;
    private Date date;
    private Date dateNotification;

    public EventClass (int id, String title, String content, int idDeansOffice,
                       String deansOfficeName, String dateString, String dateNotificationString) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.idDeansOffice = idDeansOffice;
        this.deansOfficeName = deansOfficeName;
        this.date = stringToDate(dateString);
        this.dateNotification = stringToDate(dateNotificationString);
    }

    private Date stringToDate (String string) {
        // Format: "4/21/2016 12:00:00 AM"
        Date tempDate = null;
        SimpleDateFormat format = new SimpleDateFormat("MM-dd-yyyy' 'HH:mm:ss' 'aa");
        try {
            tempDate = format.parse(string);
        } catch (ParseException e) {
            e.printStackTrace();
        }
        return tempDate;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public int getIdDeansOffice() {
        return idDeansOffice;
    }

    public void setIdDeansOffice(int idDeansOffice) {
        this.idDeansOffice = idDeansOffice;
    }

    public String getDeansOfficeName() {
        return deansOfficeName;
    }

    public void setDeansOfficeName(String deansOfficeName) {
        this.deansOfficeName = deansOfficeName;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(String string) {
        this.date = stringToDate(string);
    }

    public Date getDateNotification() {
        return dateNotification;
    }

    public void setDateNotification(String string) {
        this.dateNotification = stringToDate(string);
    }
}
