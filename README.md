# LF2DD
LF2DD is a simple command line utility, extracting raw text data out of needlessly encoded Little Fighter 2 data files.

## Usage
 * LF2DD.exe encrypt [file to encrypt] [output file]
 * LF2DD.exe decrypt [file to decrypt] [output file]

## Format of the LF2 encryption
So for whatever reason LF2 data files are 'encrypted'. Fine.

Each .dat file starts with a 123 byte long header which you can ignore, since it does not contain any meaningful data. After that the actual file data starts. Each encrypted character (byte) corresponds to one ASCII character. The formula for encrypting a character goes like this:

```
    Encrypted = CharToEncrypt + Key[CharacterIndex % 37]
```

Keep in mind that overflows might apply. CharacterIndex is index of the character in text file you're encrypting. The key appears to be `odBearBecauseHeIsVeryGoodSiuHungIsAGo`. Now, with that in mind we can logically create the decryption formula:

```
    Decrypted = CharToDecrypt - Key[CharacterIndex % 37]
```

## License
I don't care what you want to do with the 100 lines of code I wrote, you can consider it to be in public domain. Just don't be evil:tm:
