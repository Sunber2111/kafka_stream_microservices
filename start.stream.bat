# create indices with mappings
# curl -i -X PUT -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:9200/users -d @ConfigsStream/mappings/users.json
# curl -i -X PUT -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:9200/posts -d @ConfigsStream/mappings/posts.json
# curl -i -X PUT -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:9200/comments -d @ConfigsStream/mappings/comments.json

# setup connections
curl -i -X POST -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:8083/connectors/ -d @ConfigsStream/connections/es-sink-users.json
# curl -i -X POST -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:8083/connectors/ -d @ConfigsStream/connections/es-sink-posts.json
# curl -i -X POST -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:8083/connectors/ -d @ConfigsStream/connections/es-sink-comments.json
curl -i -X POST -H "Accept:application/json" -H  "Content-Type:application/json" http://localhost:8083/connectors/ -d @ConfigsStream/connections/source.json
