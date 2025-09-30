# Modern Web Uygulaması

Kurumsal seviyede, Next.js 15 (App Router) + ASP.NET Core (.NET 9) tabanlı full‑stack bir örnek uygulama.

## Hızlı Başlangıç

1. Altyapıyı başlatın:

```bash
cd deploy/docker
# Geliştirme servisleri (Postgres, Redis, Keycloak, Backend, Frontend, Seq, SonarQube)
docker-compose up -d
```

2. Servislere erişim

- Backend API: `http://localhost:5000`
- Swagger: `http://localhost:5000/swagger`
- Frontend: `http://localhost:3000`
- Keycloak: `http://localhost:8080`
- Seq: `http://localhost:5341`
- SonarQube: `http://localhost:9000`

## Proje Yapısı

`docs` ve `deploy` klasörleri ile `src/backend`, `src/frontend` iskeleti oluşturulmuştur. Ayrıntılı mimari ve standartlar için `docs/` klasörüne bakınız.
