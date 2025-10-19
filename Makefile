SCRIPT_DIR := ../scripts
DOCKER_DIR := docker

start:
	cd $(DOCKER_DIR) && bash $(SCRIPT_DIR)/start.sh

cleanup:
	cd $(DOCKER_DIR) && bash $(SCRIPT_DIR)/cleanup.sh

stop:
	cd $(DOCKER_DIR) && bash $(SCRIPT_DIR)/stop.sh
