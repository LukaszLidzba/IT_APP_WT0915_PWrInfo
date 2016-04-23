package pl.ziwg.pwrinfo;

public class MessagesClass {
    private int id;
    private String title;
    private String content;
    private int idDeansOffice;
    private String deansOfficeName;
    private boolean important;

    public MessagesClass (int id, String title, String content, int idDeansOffice, String deansOfficeName, boolean important) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.idDeansOffice = idDeansOffice;
        this.deansOfficeName = deansOfficeName;
        this.important = important;
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

    public boolean isImportant() {
        return important;
    }

    public void setImportant(boolean important) {
        this.important = important;
    }
}
