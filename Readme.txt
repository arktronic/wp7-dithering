ARKconcepts dithering example app


This app demonstrates image dithering algorithms (as best understood by me) implemented for WP7.
They are useful when displaying 24- and 32-bpp images on 16bpp devices or in apps that don't enable 32bpp mode.

Normally, WP7 and WP7.5 downsample images in 16bpp apps without dithering, which causes ugly artifacts.
Although since Mango it's possible to enable 32bpp, it makes the app render more slowly and is actually nonfunctional in 256MB RAM devices.

The Sierra Lite (Sierra-2-4A) algorithm is fastest, and actually appears to work best with the included images.
The other algorithms are provided for comparison (and bug discovery?)
