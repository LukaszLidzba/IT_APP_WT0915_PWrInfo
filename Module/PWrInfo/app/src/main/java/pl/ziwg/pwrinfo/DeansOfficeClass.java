package pl.ziwg.pwrinfo;

public class DeansOfficeClass {
    private int id;
    private String name;
    private String address;
    private String additionalInfo;
    private String openingHours;

    public DeansOfficeClass (int id, String name, String address, String additionalInfo, String openingHours) {
        this.id = id;
        this.name = name;
        this.address = address;
        this.additionalInfo = additionalInfo;
        this.openingHours = openingHours;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getAdditionalInfo() {
        return additionalInfo;
    }

    public void setAdditionalInfo(String additionalInfo) {
        this.additionalInfo = additionalInfo;
    }

    public String getOpeningHours() {
        return openingHours;
    }

    public void setOpeningHours(String openingHours) {
        this.openingHours = openingHours;
    }
}

