namespace refitwalkthrough;
//example response from https://www.boredapi.com/api/activity
//{"activity":"Go to an escape room","type":"social","participants":4,"price":0.5,"link":"","key":"5585829","accessibility":0.3}

public record ActivityDTO(string Activity, string Type, int Participants, double Price, string Link, string Key, double Accessibility );