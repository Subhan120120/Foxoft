// Foxoft QR Scanner & Device Helper
class QrCameraScanner {
  constructor(videoElement, onScanCallback) {
    this.video = videoElement;
    this.onScan = onScanCallback;
    this.stream = null;
    this.scanning = false;
    this.detector = null;
    this.canvas = document.createElement('canvas');
    this.ctx = this.canvas.getContext('2d');
  }

  async start() {
    try {
      if ('BarcodeDetector' in window) {
        this.detector = new window.BarcodeDetector({ formats: ['qr_code'] });
      }

      const constraints = {
        video: {
          facingMode: { ideal: 'environment' },
          width: { ideal: 1280 },
          height: { ideal: 720 }
        },
        audio: false
      };

      this.stream = await navigator.mediaDevices.getUserMedia(constraints);
      this.video.srcObject = this.stream;
      await this.video.play();
      this.scanning = true;
      this.scanLoop();
      return true;
    } catch (err) {
      console.error('Kamera açılmadı:', err);
      throw err;
    }
  }

  stop() {
    this.scanning = false;
    if (this.stream) {
      this.stream.getTracks().forEach(track => track.stop());
      this.stream = null;
    }
    if (this.video) {
      this.video.srcObject = null;
    }
  }

  async scanLoop() {
    if (!this.scanning) return;

    if (this.video.readyState === this.video.HAVE_ENOUGH_DATA) {
      try {
        if (this.detector) {
          const barcodes = await this.detector.detect(this.video);
          if (barcodes.length > 0) {
            const rawValue = barcodes[0].rawValue;
            if (rawValue && rawValue.startsWith('FOXQR:')) {
              this.scanning = false;
              this.onScan(rawValue);
              return;
            }
          }
        }
      } catch (e) {
        // Detektor xətası olarsa davam edir
      }
    }

    if (this.scanning) {
      requestAnimationFrame(() => this.scanLoop());
    }
  }
}

// Cihaz İdentifikatoru və GPS Köməkçisi
const FoxoftDevice = {
  getDeviceId() {
    let id = localStorage.getItem('foxoft_device_token');
    if (!id) {
      if (window.crypto && window.crypto.randomUUID) {
        id = 'DEV-' + window.crypto.randomUUID();
      } else {
        id = 'DEV-' + Math.random().toString(36).substring(2, 12) + '-' + Date.now().toString(36);
      }
      localStorage.setItem('foxoft_device_token', id);
    }
    return id;
  },

  getDeviceName() {
    const ua = navigator.userAgent;
    if (/android/i.test(ua)) return 'Android Cihaz';
    if (/iPhone|iPad|iPod/i.test(ua)) return 'Apple iOS Cihaz';
    if (/Windows/i.test(ua)) return 'Windows Cihaz';
    if (/Macintosh/i.test(ua)) return 'Mac OS Cihaz';
    return 'Web Brauzer';
  },

  getCurrentLocation() {
    return new Promise((resolve, reject) => {
      if (!navigator.geolocation) {
        reject(new Error('Brauzeriniz Geolocation API dəstəkləmir.'));
        return;
      }

      navigator.geolocation.getCurrentPosition(
        (pos) => {
          resolve({
            latitude: pos.coords.latitude,
            longitude: pos.coords.longitude,
            accuracy: pos.coords.accuracy
          });
        },
        (err) => {
          let msg = 'Məkan əldə edilmədi.';
          if (err.code === 1) msg = 'Məkana icazə verilmədi. Zəhmət olmasa GPS icazəsini aktiv edin.';
          else if (err.code === 2) msg = 'GPS siqnalı tapılmadı.';
          else if (err.code === 3) msg = 'Məkan sorğusu vaxt aşımına uğradı.';
          reject(new Error(msg));
        },
        {
          enableHighAccuracy: true,
          timeout: 10000,
          maximumAge: 0
        }
      );
    });
  }
};
