//import { precacheAndRoute } from 'workbox-precaching/precacheAndRoute';
importScripts(
    'https://storage.googleapis.com/workbox-cdn/releases/6.4.1/workbox-sw.js'
  );
  const {precacheAndRoute} = workbox.cacheableResponse; 
  precacheAndRoute([ 
    {url: '/index.html', revision: null},
    {url: '/js/sw.js', revision: null},
    {url: '/css/*', revision: null},
    {url: '/images/*', revision: null},
    {url: '/offline.html', revision: null}
  ]);
