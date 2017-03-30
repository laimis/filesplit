function send-data($data) {
    $apiUrl = "http://localhost:5000/api/records"

    Invoke-WebRequest -Method POST -ContentType "text/plain" -Body $data $apiUrl
}

send-data "Franklin|Rosy|Female|Green|04/22/1999"
send-data "Gagarin|Yuri|Male|Space|04/01/1972"
send-data "Smith|Jane|Female|Blue|05/22/2009"
send-data "Ronalds|Tom|Male|Black|11/02/1950"