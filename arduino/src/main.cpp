#include <Arduino.h>

const int sensor = A0;
int16_t temperatura;
byte temp_byte[8];

int checkSum(byte msg[]);

void setup() {
  Serial.begin(9600);
}

void loop() {
  temperatura = analogRead(sensor);

  temp_byte[0] = 0x12; // byte de início da mensagem
  temp_byte[1] = 97; // byte para identificar a mensagem
  temp_byte[2] = 8; // byte com a quantidade de dados

  temp_byte[3] = lowByte(temperatura);
  temp_byte[4] = highByte(temperatura);

  int cs = checkSum(temp_byte);
  temp_byte[5] = lowByte(cs);
  temp_byte[6] = highByte(cs);
  
  temp_byte[7] = 0x13; // byte de fim da mensagem

  Serial.write(temp_byte, 8);
  delay(1000);
}

int checkSum(byte msg[]) {
  int checksum = 0;
  for (int i = 0; i < 5; i++)
  {
    checksum += msg[i];
  }
  return checksum;
}