const PROXY_CONFIG = [
  {
    context: [
      "/Country",
    ],
    target: "https://localhost:7115",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
