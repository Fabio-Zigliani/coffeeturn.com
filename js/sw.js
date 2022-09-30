
  import { precacheAndRoute } from 'workbox-precaching/precacheAndRoute';

  precacheAndRoute([ 
    {url: '/index.html', revision: null},
    {url: '/js/sw.js', revision: null},
    {url: '/css/*', revision: null},
    {url: '/images/*', revision: null},
    {url: '/offline.html', revision: null}
  ]);
