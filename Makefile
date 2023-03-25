.DEFAULT_GOAL := build-debug

.PHONY: run
run:
	dotnet run --project Backend

.PHONY: test
test: unit-tests integration-tests component-tests

.PHONY: unit-tests
unit-tests: build-debug
	dotnet test --nologo --no-build --logger "console;verbosity=detailed" --filter "Tests.Unit"
	dotnet test --nologo --no-build --logger "console;verbosity=detailed" --filter "Tests.Unit"

.PHONY: integration-tests
integration-tests: build-debug
	dotnet test --nologo --no-build --logger "console;verbosity=detailed" --filter "Tests.Integration"
	dotnet test --nologo --no-build --logger "console;verbosity=detailed" --filter "Tests.Integration"

.PHONY: component-tests
component-tests: build-debug
	dotnet test --nologo --no-build --logger "console;verbosity=detailed" --filter "Tests.Component"
	dotnet test --nologo --no-build --logger "console;verbosity=detailed" --filter "Tests.Component"

.PHONY: build-debug
build-debug: restore
	dotnet build --no-restore --configuration Debug


.PHONY: clean
clean:
	dotnet clean

.PHONY: restore
restore:
	@echo "restoring..."
	@dotnet restore --use-lock-file --locked-mode

.PHONY: lint
lint: restore lint-dotnet
	@echo "lint done"

.PHONY: lint-dotnet
lint-dotnet: restore
	@echo "style"
	@dotnet format --no-restore style --verbosity minimal --severity warn
	@echo "analyzers"
	@dotnet format --no-restore analyzers --verbosity minimal --severity warn

.PHONY: check-lint
check-lint: restore check-lint-terraform check-lint-dotnet
	@echo "check-lint done"

.PHONY: check-lint-dotnet
check-lint-dotnet: restore
	@echo "style"
	@dotnet format --no-restore style --verbosity minimal --severity warn --verify-no-changes
	@echo "analyzers"
	@dotnet format --no-restore analyzers --verbosity minimal --severity warn --verify-no-changes

.PHONY: fmt
fmt: restore fmt-dotnet
	@echo "fmt done"

.PHONY: fmt-dotnet
fmt-dotnet: restore
	@echo "dotnet"
	@dotnet format --no-restore whitespace --verbosity normal

.PHONY: check-fmt
check-fmt: restore  check-fmt-dotnet
	@echo "check-fmt done"

.PHONY: check-fmt-dotnet
check-fmt-dotnet: restore
	@echo "dotnet"
	@dotnet format --no-restore whitespace --verbosity normal --verify-no-changes

.PHONY: asdf
asdf: .tool-versions ./scripts/asdf-plugins.sh
	@echo "preparing asdf"
	@./scripts/asdf-plugins.sh
	@asdf install

.PHONY: dev-cert
dev-cert: ./scripts/dev-cert.sh
	@echo "preparing developer certificates"
	@./scripts/dev-cert.sh

