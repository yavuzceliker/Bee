const CODE_TYPES = [
    { text: "Code 128(Kovan Barkodu)", value: "code_128" },
    { text: "QR Code", value: "qrcode" },
    { text: "Code 39", value: "code_39" },
    { text: "Code 39 VIN", value: "code_39_vin" },
    { text: "EAN", value: "ean" },
    { text: "EAN-extended", value: "ean_extended" },
    { text: "EAN-8", value: "ean_8" },
    { text: "UPC", value: "upc" },
    { text: "UPC-E", value: "upc_e" },
    { text: "Codabar", value: "codabar" },
    { text: "Interleaved 2 of 5", value: "i2of5" },
    { text: "Standard 2 of 5", value: "2of5" },
    { text: "Code 93", value: "code_93" }],

    STREAM_SIZES = [
        { text: "320px", value: 320 },
        { text: "640px", value: 640 },
        { text: "800px", value: 800 },
        { text: "1280px", value: 1280 },
        { text: "1600px", value: 1600 },
        { text: "1920px", value: 1920 }],

    STREAM_CONSTRAINTS = [
        { text: "320px", value: "320x240" },
        { text: "640px", value: "640x480" },
        { text: "800px", value: "800x600" },
        { text: "1280px", value: "1280x720" },
        { text: "1600px", value: "1600x960" },
        { text: "1920px", value: "1920x1080" }],

    PATCH_SIZES = [
        { text: "x-small", value: "x-small" },
        { text: "small", value: "small" },
        { text: "medium", value: "medium" },
        { text: "large", value: "large" },
        { text: "x-large", value: "x-large" }],

    WORKERS = [
        { text: "1", value: 1 },
        { text: "2", value: 2 },
        { text: "4", value: 4 },
        { text: "8", value: 8 }];